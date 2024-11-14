using Volcanion.Core.Services.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Request;
using Volcanion.Identity.Models.Response;

namespace Volcanion.Identity.Services.Abstractions;

/// <summary>
/// IAccountService
/// </summary>
public interface IAccountService : IBaseService<Account>
{
    /// <summary>
    /// Register
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    Task<AccountResponse?> Register(AccountRegister account);

    /// <summary>
    /// Login
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    Task<AccountResponse?> Login(AccountLogin account);

    /// <summary>
    /// RefreshToken
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AccountResponse?> RefreshToken(TokenRequest request);
}
