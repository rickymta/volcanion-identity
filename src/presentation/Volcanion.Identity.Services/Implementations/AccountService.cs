using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volcanion.Core.Common.Abstractions;
using Volcanion.Core.Models.Enums;
using Volcanion.Core.Models.Jwt;
using Volcanion.Core.Presentation.Middlewares.Exceptions;
using Volcanion.Core.Services.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Request;
using Volcanion.Identity.Models.Response;
using Volcanion.Identity.Models.Setting;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Services.Implementations;

/// <inheritdoc />
internal class AccountService : BaseService<Account, IAccountRepository>, IAccountService
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
    /// IHahsProvider instance
    /// </summary>
    private readonly IHashProvider _hashProvider;

    /// <summary>
    /// IGrantPermissionRepository instance
    /// </summary>
    private readonly IGrantPermissionRepository _grantPermissionRepository;

    /// <summary>
    /// AllowedOrigin
    /// </summary>
    private string[] AllowedOrigin { get; set; }

    /// <summary>
    /// Audience
    /// </summary>
    private string Audience { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="logger"></param>
    /// <param name="hashProvider"></param>
    public AccountService(IAccountRepository repository, ILogger<BaseService<Account, IAccountRepository>> logger, IHashProvider hashProvider, IConfigProvider configProvider, IOptions<AppSettings> options, IGrantPermissionRepository grantPermissionRepository) : base(repository, logger)
    {
        _hashProvider = hashProvider;
        AllowedOrigin = options.Value.AllowedOrigins;
        Audience = options.Value.Audience;
        _grantPermissionRepository = grantPermissionRepository;
    }

    /// <inheritdoc />
    public async Task<AccountResponse?> Login(AccountLogin account)
    {
        // Find account by email
        var accountFind = await _repository.GetAccountByEmail(account.LoginName);
        // If account not found, return null
        if (accountFind == null) return null;
        // Verify password
        if (_hashProvider.VerifyPassword(accountFind.Password, account.Password)) return null;

        // Generate resource access
        var resourceAccess = await GenerateResourceAccessFromRole(accountFind.Id) ?? throw new VolcanionBusinessException("Cannot generate resource access!");
        // Generate account response and return
        return GenerateAccountResponse(accountFind, account.Issuer, account.RememberMe, resourceAccess);
    }

    /// <inheritdoc />
    public async Task<AccountResponse?> RefreshToken(TokenRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<AccountResponse?> Register(AccountRegister account)
    {
        // Find account by email
        var accountFind = await _repository.GetAccountByEmail(account.Email);
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
        var res = await _repository.CreateAsync(registerAccount);
        // If account not saved, return null
        if (res == Guid.Empty) return null;
        // Generate resource access
        var resourceAccess = await GenerateResourceAccessFromRole(res) ?? throw new VolcanionBusinessException("Cannot generate resource access!");
        // Generate account response and return
        return GenerateAccountResponse(registerAccount, account.Issuer, true, resourceAccess);
    }

    /// <summary>
    /// GenerateAccountResponse
    /// </summary>
    /// <param name="account"></param>
    /// <param name="issuer"></param>
    /// <param name="rememberMe"></param>
    /// <param name="resourceAccess"></param>
    /// <returns></returns>
    private AccountResponse GenerateAccountResponse(Account account, string issuer, bool rememberMe, ResourceAccess resourceAccess)
    {
        // Get group access from account id
        var groupAccess = GetGroupAccess(account.Id);

        // Generate access token
        var refreshToken = "";
        var accessToken = _jwtProvider.GenerateJwt(account, Audience, issuer, AllowedOrigin.ToList(), groupAccess, resourceAccess, JwtType.AccessToken);

        // If remember me is true, generate refresh token
        if (rememberMe)
        {
            refreshToken = _jwtProvider.GenerateJwt(account, Audience, issuer, AllowedOrigin.ToList(), groupAccess, resourceAccess, JwtType.RefreshToken);
        }

        // Return account response
        return new AccountResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Account = account
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
        var grantPermission = await _grantPermissionRepository.GetGrantPermissionByAccountId(accountId);

        // If grant permission is null, return null
        if (grantPermission?.RolePermissions?.Count > 0)
        {
            // Generate roles from grant permission
            var roles = grantPermission.RolePermissions.Select(rp => $"{rp.Role.Name}.{rp.Permission.Name}").ToList();

            // Return resource access
            return new ResourceAccess
            {
                RoleAccess = new RoleAccess { Roles = roles }
            };
        }

        return null;
    }

    /// <summary>
    /// GetGroupAccess
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    private List<string> GetGroupAccess(Guid accountId)
    {
        // TODO: implement group access
        var groupAccess = new List<string>();
        return groupAccess;
    }
}
