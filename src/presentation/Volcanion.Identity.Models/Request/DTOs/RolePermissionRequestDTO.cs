namespace Volcanion.Identity.Models.Request.DTOs;

/// <summary>
/// RolePermissionRequestDTO
/// </summary>
public class RolePermissionRequestDTO
{
    /// <summary>
    /// RoleId
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// PermissionId
    /// </summary>
    public Guid PermissionId { get; set; }

    /// <summary>
    /// GrantPermissionId
    /// </summary>
    public Guid GrantPermissionId { get; set; }
}
