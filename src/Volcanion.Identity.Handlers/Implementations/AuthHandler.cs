using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Request;
using Volcanion.Identity.Models.Response;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Handlers.Implementations;

/// <inheritdoc/>
internal class AuthHandler : IAuthHandler
{
    /// <summary>
    /// IAuthService
    /// </summary>
    private readonly IAuthService _authService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="authService"></param>
    public AuthHandler(IAuthService authService)
    {
        _authService = authService;
    }

    /// <inheritdoc/>
    public async Task<LoginResponse?> Login(AccountLogin account)
    {
        return await _authService.Login(account);
    }

    /// <inheritdoc/>
    public async Task<LoginResponse?> RefreshToken(TokenRequest request)
    {
        return await _authService.RefreshToken(request);
    }

    /// <inheritdoc/>
    public async Task<LoginResponse?> Register(AccountRegister account)
    {
        return await _authService.Register(account);
    }
}
