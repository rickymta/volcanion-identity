using Volcanion.Core.Models.Enums;

namespace Volcanion.Identity.Models.Request;

/// <summary>
/// TokenRequest
/// </summary>
public class TokenRequest
{
    /// <summary>
    /// Token
    /// </summary>
    public string Token { get; set; } = null!;
}
