using Volcanion.Core.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Request;
using Volcanion.Identity.Models.Response;

namespace Volcanion.Identity.Handlers.Abstractions;

/// <summary>
/// IAccountHandler
/// </summary>
public interface IAccountHandler : IBaseHandler<Account>
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
