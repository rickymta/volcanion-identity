using Newtonsoft.Json;
using Volcanion.Core.Models.Entities;

namespace Volcanion.Identity.Models.Entities;

/// <summary>
/// Account Entity
/// </summary>
public class Account : BaseEntity
{
    /// <summary>
    /// Fullname
    /// </summary>
    [JsonProperty("fullname")]
    public string Fullname { get; set; } = null!;

    /// <summary>
    /// Email
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; } = null!;

    /// <summary>
    /// Password
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Avatar
    /// </summary>
    [JsonProperty("avatar")]
    public string? Avatar { get; set; }

    /// <summary>
    /// Address
    /// </summary>
    [JsonProperty("address")]
    public string? Address { get; set; }

    /// <summary>
    /// PhoneNumber
    /// </summary>
    [JsonProperty("phoneNumber")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Birthday
    /// </summary>
    [JsonProperty("birthday")]
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// GrantPermissions
    /// </summary>
    [JsonIgnore]
    public ICollection<GrantPermission> GrantPermissions { get; set; } = [];
}
