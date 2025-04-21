using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volcanion.Core.Models.Attributes;
using Volcanion.Core.Presentation.Controllers;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Request;

namespace Volcanion.Identity.Presentation.Controllers;

/// <summary>
/// AuthController
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[AllowAnonymous]
public class AuthController : BaseController
{
    /// <summary>
    /// ILogger instance
    /// </summary>
    private readonly ILogger<AuthController> _logger;

    /// <summary>
    /// IAuthHandler instance
    /// </summary>
    private readonly IAuthHandler _authHandler;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="authHandler"></param>
    public AuthController(ILogger<AuthController> logger, IAuthHandler authHandler)
    {
        _logger = logger;
        _authHandler = authHandler;
    }

    /// <summary>
    /// Register
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(AccountRegister account)
    {
        var result = await _authHandler.Register(account);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// Login
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(AccountLogin account)
    {
        var result = await _authHandler.Login(account);
        if (result == null) return BadRequest(ErrorMessage("Invalid username or password!"));
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// RefreshToken
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("refresh-token")]
    [VolcanionAuth([])]
    public async Task<IActionResult> RefreshToken(TokenRequest request)
    {
        var result = await _authHandler.RefreshToken(request);
        if (result == null) return BadRequest(ErrorMessage("There're error while handle request! Please try again!"));
        return Ok(SuccessData(result));
    }
}
