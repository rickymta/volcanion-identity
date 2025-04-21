namespace Volcanion.Identity.Models.Request;

/// <summary>
/// AccountLogin
/// </summary>
public class AccountLogin
{
    /// <summary>
    /// PhoneNumber
    /// </summary>
    public string PhoneNumber { get; set; } = null!;

    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// RememberMe
    /// </summary>
    public bool RememberMe { get; set; } = false;

    /// <summary>
    /// Issuer
    /// </summary>
    public string Issuer { get; set; } = null!;
}
