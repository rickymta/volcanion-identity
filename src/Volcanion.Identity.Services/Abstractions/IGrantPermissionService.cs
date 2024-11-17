using Volcanion.Core.Services.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;

namespace Volcanion.Identity.Services.Abstractions;

/// <summary>
/// IGrantPermissionService
/// </summary>
public interface IGrantPermissionService : IBaseService<GrantPermission, GrantPermissionFilter>
{
}
