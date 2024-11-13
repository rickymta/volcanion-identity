﻿using Volcanion_Core_Models.Entities;

namespace Volcanion_Identity_Models.Entities;

/// <summary>
/// Account Entity
/// </summary>
public class Account : BaseEntity
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

    /// <summary>
    /// GrantPermissions
    /// </summary>
    public ICollection<GrantPermission> GrantPermissions { get; set; }
}