using Volcanion_Identity_Models.Entities;

namespace Volcanion_Identity_Models.Response;

/// <summary>
/// AccountResponse
/// </summary>
public class AccountResponse
{
    /// <summary>
    /// Account
    /// </summary>
    public Account Account { get; set; }

    /// <summary>
    /// AccessToken
    /// </summary>
    public string AccessToken { get; set; } = null!;

    /// <summary>
    /// RefreshToken
    /// </summary>
    public string RefreshToken { get; set; } = null!;
}
