namespace Volcanion_Identity_Models.Response.BOs;

/// <summary>
/// AccountResponseBO
/// </summary>
public class AccountResponseBO
{
    /// <summary>
    /// GUID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// IsActived
    /// </summary>
    public bool IsActived { get; set; }

    /// <summary>
    /// IsDeleted
    /// </summary>
    public bool IsDeleted { get; set; }

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

    /// <summary>
    /// CreatedAt
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// CreatedId
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// UpdatedAt
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// UpdatedId
    /// </summary>
    public string? UpdatedBy { get; set; }
}
