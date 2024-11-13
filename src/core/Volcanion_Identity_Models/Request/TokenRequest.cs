using Volcanion_Core_Models.Enums;

namespace Volcanion_Identity_Models.Request;

/// <summary>
/// TokenRequest
/// </summary>
public class TokenRequest
{
    /// <summary>
    /// Token
    /// </summary>
    public string Token { get; set; } = null!;

    /// <summary>
    /// JwtType
    /// </summary>
    public JwtType Type { get; set; }

    /// <summary>
    /// Id
    /// </summary>
    public string Id { get; set; } = null!;
}
