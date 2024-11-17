using Volcanion.Identity.Models.Request;
using Volcanion.Identity.Models.Response;

namespace Volcanion.Identity.Handlers.Abstractions;

public interface IAuthHandler
{
    /// <summary>
    /// Register
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    Task<LoginResponse?> Register(AccountRegister account);

    /// <summary>
    /// Login
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    Task<LoginResponse?> Login(AccountLogin account);

    /// <summary>
    /// RefreshToken
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<LoginResponse?> RefreshToken(TokenRequest request);
}
