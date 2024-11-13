namespace Volcanion_Identity_Models.Request.DTOs;

/// <summary>
/// AccountRequestDTO
/// </summary>
public class AccountRequestDTO
{
    /// <summary>
    /// Fullname
    /// </summary>
    public string Fullname { get; set; } = null!;

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Avatar
    /// </summary>
    public string? Avatar { get; set; }

    /// <summary>
    /// Address
    /// </summary>
    public string? Address { get; set; }
}
