using Volcanion_Core_Handlers.Abstractions;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Models.Request;
using Volcanion_Identity_Models.Response;

namespace Volcanion_Identity_Handlers.Abstractions;

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
