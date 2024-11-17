using Microsoft.Extensions.Options;
using Volcanion.Core.Common.Abstractions;
using Volcanion.Core.Models.Enums;
using Volcanion.Core.Models.Jwt;
using Volcanion.Core.Presentation.Middlewares.Exceptions;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Request;
using Volcanion.Identity.Models.Response;
using Volcanion.Identity.Models.Setting;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Services.Implementations;

/// <inheritdoc />
internal class AuthService : IAuthService
{
    /// <summary>
    /// ICacheProvider
    /// </summary>
    private readonly IRedisCacheProvider _redisCacheProvider;

    /// <summary>
    /// IJwtProvider
    /// </summary>
    private readonly IJwtProvider _jwtProvider;

    /// <summary>
    /// IGrantPermissionRepository instance
    /// </summary>
    private readonly IGrantPermissionRepository _grantPermissionRepository;

    /// <summary>
    /// IHahsProvider instance
    /// </summary>
    private readonly IHashProvider _hashProvider;

    /// <summary>
    /// IAccountRepository instance
    /// </summary>
    private readonly IAccountRepository _accountRepository;

    /// <summary>
    /// AllowedOrigin
    /// </summary>
    private string[] AllowedOrigin { get; set; }

    /// <summary>
    /// Audience
    /// </summary>
    private string Audience { get; set; }

    public AuthService(IRedisCacheProvider redisCacheProvider, IJwtProvider jwtProvider, IGrantPermissionRepository grantPermissionRepository, IHashProvider hashProvider, IAccountRepository accountRepository, IOptions<AppSettings> options)
    {
        _redisCacheProvider = redisCacheProvider;
        _jwtProvider = jwtProvider;
        _grantPermissionRepository = grantPermissionRepository;
        _hashProvider = hashProvider;
        _accountRepository = accountRepository;
        AllowedOrigin = options.Value.AllowedOrigins;
        Audience = options.Value.Audience;
    }

    /// <inheritdoc />
    public async Task<LoginResponse?> Login(AccountLogin account)
    {
        // Find account by email
        var accountFind = await _accountRepository.GetAccountByEmail(account.LoginName);
        // If account not found, return null
        if (accountFind == null) return null;
        // Verify password
        if (!_hashProvider.VerifyPassword(accountFind.Password, account.Password)) return null;

        // Generate resource access
        var resourceAccess = await GenerateResourceAccessFromRole(accountFind.Id) ?? throw new VolcanionBusinessException("Cannot generate resource access!");

        // Generate session id and save to redis cache
        var sessionId = Guid.NewGuid().ToString();
        _ = _redisCacheProvider.SetStringAsync(sessionId, "Valid");
        // Generate account response and return
        return GenerateAccountResponse(accountFind, account.Issuer, account.RememberMe, resourceAccess, sessionId);
    }

    /// <inheritdoc />
    public async Task<LoginResponse?> RefreshToken(TokenRequest request)
    {
        // Validate refresh token
        if (!_jwtProvider.ValidateJwt(request.Token, JwtType.RefreshToken)) return null;
        // Decode refresh token and get payload
        var payload = _jwtProvider.DecodeJwt(request.Token).payload;
        // If payload is null, return null
        if (payload == null) return null;

        // Find account by email from payload
        var accountFind = await _accountRepository.GetAccountByEmail(payload.Email);
        // If account not found, return null
        if (accountFind == null) return null;

        // Generate resource access
        var resourceAccess = await GenerateResourceAccessFromRole(accountFind.Id) ?? throw new VolcanionBusinessException("Cannot generate resource access!");

        // Generate session id and save to redis cache
        var sessionId = Guid.NewGuid().ToString();
        _ = _redisCacheProvider.SetStringAsync(sessionId, "Valid");
        // Generate account response and return
        return GenerateAccountResponse(accountFind, payload.Issuer, true, resourceAccess, sessionId);
    }

    /// <inheritdoc />
    public async Task<LoginResponse?> Register(AccountRegister account)
    {
        // Find account by email
        var accountFind = await _accountRepository.GetAccountByEmail(account.Email);
        // If account found, throw exception
        if (accountFind != null) throw new VolcanionBusinessException("Email is exists!");

        // Create new account
        var registerAccount = new Account
        {
            Address = account.Address,
            Email = account.Email,
            Fullname = account.Fullname,
            Password = _hashProvider.HashPassword(account.Password)
        };

        // Save account to database
        var res = await _accountRepository.CreateAsync(registerAccount);
        // If account not saved, return null
        if (res == Guid.Empty) return null;
        // Generate resource access
        var resourceAccess = await GenerateResourceAccessFromRole(res) ?? throw new VolcanionBusinessException("Cannot generate resource access!");

        // Generate session id and save to redis cache
        var sessionId = Guid.NewGuid().ToString();
        _ = _redisCacheProvider.SetStringAsync(sessionId, "Valid");
        // Generate account response and return
        return GenerateAccountResponse(registerAccount, account.Issuer, true, resourceAccess, sessionId);
    }

    /// <summary>
    /// GenerateAccountResponse
    /// </summary>
    /// <param name="account"></param>
    /// <param name="issuer"></param>
    /// <param name="rememberMe"></param>
    /// <param name="resourceAccess"></param>
    /// <returns></returns>
    private LoginResponse GenerateAccountResponse(object data, string issuer, bool rememberMe, ResourceAccess resourceAccess, string sessionId)
    {
        // Generate access token
        var refreshToken = "";
        var accessToken = _jwtProvider.GenerateJwt(data, Audience, issuer, [.. AllowedOrigin], resourceAccess, JwtType.AccessToken, sessionId);

        // If remember me is true, generate refresh token
        if (rememberMe)
        {
            refreshToken = _jwtProvider.GenerateJwt(data, Audience, issuer, [.. AllowedOrigin], resourceAccess, JwtType.RefreshToken, sessionId);
        }

        // Return account response
        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Data = data
        };
    }

    /// <summary>
    /// GenerateResourceAccessFromRole
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    private async Task<ResourceAccess?> GenerateResourceAccessFromRole(Guid accountId)
    {
        // Get grant permission by account id
        var grantPermissions = await _grantPermissionRepository.GetGrantPermissionByAccountId(accountId);
        var roles = new List<string>();

        if (grantPermissions != null && grantPermissions.Count > 0)
        {
            var roleFound = grantPermissions.Select(rp => $"{rp.RoleName}.{rp.PermissionName}").ToList();
            if (roleFound != null && roleFound.Count > 0) roles.AddRange(roleFound);
        }

        // Return resource access
        return new ResourceAccess
        {
            RoleAccess = new RoleAccess { Roles = roles }
        };
    }
}
