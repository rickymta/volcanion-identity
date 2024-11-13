﻿using Volcanion_Core_Models.Entities;

namespace Volcanion_Identity_Models.Entities;

/// <summary>
/// GrantPermission
/// </summary>
public class GrantPermission : BaseEntity
{
    /// <summary>
    /// AccountId
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// RolePermissionId
    /// </summary>
    public Guid RolePermissionId { get; set; }

    /// <summary>
    /// Account
    /// </summary>
    public Account Account { get; set; }

    /// <summary>
    /// RolePermissions
    /// </summary>
    public ICollection<RolePermission> RolePermissions { get; set; }
}