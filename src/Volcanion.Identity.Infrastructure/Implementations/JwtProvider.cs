using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Volcanion.Core.Common.Abstractions;
using Volcanion.Core.Models.Enums;
using Volcanion.Core.Models.Jwt;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Setting;

namespace Volcanion.Identity.Infrastructure.Implementations;

/// <inheritdoc/>
internal class JwtProvider : IJwtProvider
{
    /// <summary>
    /// IStringProvider instance
    /// </summary>
    private readonly IStringProvider _stringProvider;

    /// <summary>
    /// IRedisCacheProvider instance
    /// </summary>
    private readonly IRedisCacheProvider _redisCacheProvider;

    /// <summary>
    /// IHahsProvider instance
    /// </summary>
    private readonly IHashProvider _hashProvider;

    /// <summary>
    /// PrivateKeyFilePath
    /// </summary>
    private string PrivateKeyFilePath { get; set; }

    /// <summary>
    /// PublicKeyFilePath
    /// </summary>
    private string PublicKeyFilePath { get; set; }

    /// <summary>
    /// AccessTokenExpiredTime
    /// </summary>
    private string AccessTokenExpiredTime { get; set; }

    /// <summary>
    /// RefreshTokenExpiredTime
    /// </summary>
    private string RefreshTokenExpiredTime { get; set; }

    /// <summary>
    /// JwtSettings
    /// </summary>
    private readonly JwtSettings _jwtSettings;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="stringProvider"></param>
    /// <param name="redisCacheProvider"></param>
    /// <param name="hashProvider"></param>
    /// <param name="configProvider"></param>
    /// <param name="logger"></param>
    public JwtProvider(IStringProvider stringProvider, IRedisCacheProvider redisCacheProvider, IHashProvider hashProvider, IOptions<JwtSettings> options)
    {
        _stringProvider = stringProvider;
        _redisCacheProvider = redisCacheProvider;
        _hashProvider = hashProvider;
        _jwtSettings = options.Value;
        PrivateKeyFilePath = _jwtSettings.PrivateKeyFilePath;
        PublicKeyFilePath = _jwtSettings.PublicKeyFilePath;
        AccessTokenExpiredTime = _jwtSettings.AccessTokenExpiredTime;
        RefreshTokenExpiredTime = _jwtSettings.RefreshTokenExpiredTime;
    }

    /// <inheritdoc/>
    public (JwtHeader? header, JwtPayload? payload) DecodeJwt(string token)
    {
        // Split the jwt
        var jwtSplit = token.Split('.');
        // Check if the jwt is not valid
        if (jwtSplit.Length != 3) throw new Exception("Jwt is not valid.");

        // Decode the jwt
        var headerJsonStr = _hashProvider.Base64Decode(jwtSplit[0]);
        var payloadJsonStr = _hashProvider.Base64Decode(jwtSplit[1]);

        // Deserialize the jwt
        var header = JsonConvert.DeserializeObject<JwtHeader>(headerJsonStr);
        var payload = JsonConvert.DeserializeObject<JwtPayload>(payloadJsonStr);

        // Return the header and payload
        return (header, payload);
    }

    /// <inheritdoc/>
    public string GenerateJwt(Account account, string audience, string issuer, List<string> allowedOrigins, List<string> groupAccess, ResourceAccess resourceAccess, JwtType type)
    {
        // Generate header
        var header = new JwtHeader
        {
            Algorithm = "HS512",
            Type = "JWT"
        };

        // Determine expiration time
        var expirationTimeStr = type == JwtType.AccessToken ? AccessTokenExpiredTime ?? "10m" : RefreshTokenExpiredTime ?? "30d";
        var expirationUnixTime = _stringProvider.GenerateDateTimeOffsetFromString(expirationTimeStr).ToUnixTimeSeconds();

        // Generate payload
        var payload = new JwtPayload
        {
            Audience = audience,
            Issuer = issuer,
            AllowedOrigins = allowedOrigins,
            GroupAccess = groupAccess,
            Expiration = expirationUnixTime,
            ResourceAccess = resourceAccess,
            Email = account.Email,
            Name = account.Fullname
        };

        // Serialize header and payload
        var jwtHeaderBase64 = _hashProvider.Base64Encode(JsonConvert.SerializeObject(header));
        var jwtPayloadBase64 = _hashProvider.Base64Encode(JsonConvert.SerializeObject(payload));

        // Generate signature
        var signature = _hashProvider.HashSHA512($"{jwtHeaderBase64}.{jwtPayloadBase64}", PrivateKeyFilePath);

        // Construct the JWT
        return $"{jwtHeaderBase64}.{jwtPayloadBase64}.{signature}";
    }

    /// <inheritdoc/>
    public bool ValidateJwt(string jwt, JwtType type)
    {
        // Check for empty JWT and public key
        if (string.IsNullOrEmpty(jwt)) throw new Exception("Jwt is empty!");
        if (string.IsNullOrEmpty(PublicKeyFilePath)) throw new Exception("Public key file path is not set!");

        // Split JWT into components and verify signature
        var (headerPayload, _) = SplitJwt(jwt);
        if (!_hashProvider.VerifySignature(jwt, headerPayload, PublicKeyFilePath)) throw new Exception("Jwt signature is not valid!");

        // Determine expiration time based on token type
        var expirationTimeStr = type == JwtType.AccessToken ? AccessTokenExpiredTime ?? "10m" : RefreshTokenExpiredTime ?? "30d";
        var expirationUnixTime = _stringProvider.GenerateDateTimeOffsetFromString(expirationTimeStr).ToUnixTimeSeconds();

        // Decode payload and validate expiration
        var payload = DecodeJwt(headerPayload).payload;
        if (expirationUnixTime < DateTimeOffset.UtcNow.ToUnixTimeSeconds()) throw new Exception("Jwt is expired!");

        // Validate session ID from Redis cache
        var sessionId = payload!.SessionId;
        var cacheSessionId = _redisCacheProvider.GetCacheAsync<string>(sessionId).Result;
        if (cacheSessionId.Equals("Expired")) throw new Exception("Session is expired!");

        return true;
    }

    /// <inheritdoc/>
    public (string signature, string headerPayload) SplitJwt(string jwt)
    {
        // Split the jwt
        var jwtSplit = jwt.Split('.');
        // Check if the jwt is not valid
        if (jwtSplit.Length != 3) throw new Exception("Jwt is not valid.");
        // Return the signature and header payload
        return (jwtSplit[2], $"{jwtSplit[0]}.{jwtSplit[1]}");
    }
}
