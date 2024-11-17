using Volcanion.Identity.Models.Entities;

namespace Volcanion.Identity.Models.Response;

/// <summary>
/// AccountResponse
/// </summary>
public class LoginResponse
{
    /// <summary>
    /// Account
    /// </summary>
    public object? Data { get; set; }

    /// <summary>
    /// AccessToken
    /// </summary>
    public string AccessToken { get; set; } = null!;

    /// <summary>
    /// RefreshToken
    /// </summary>
    public string RefreshToken { get; set; } = null!;
}
