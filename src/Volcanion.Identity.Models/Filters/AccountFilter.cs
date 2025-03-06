using Volcanion.Core.Models.Filter;

namespace Volcanion.Identity.Models.Filters;

public class AccountFilter : FilterBase
{
    /// <summary>
    /// Fullname
    /// </summary>
    public string? Fullname { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// PhoneNumber
    /// </summary>
    public string? PhoneNumber { get; set; }
}
