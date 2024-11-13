using Volcanion_Identity_Models.Entities;

namespace Volcanion_Identity_Models.Cache;

/// <summary>
/// AccountCache
/// </summary>
public class AccountCache
{
    /// <summary>
    /// AccountData
    /// </summary>
    public Account AccountData { get; set; } = null!;

    /// <summary>
    /// RefreshToken
    /// </summary>
    public string RefreshToken { get; set; } = null!;
}
