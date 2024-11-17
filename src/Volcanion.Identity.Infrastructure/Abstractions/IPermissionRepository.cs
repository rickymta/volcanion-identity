using Volcanion.Core.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;

namespace Volcanion.Identity.Infrastructure.Abstractions;

/// <summary>
/// IPermissionRepository
/// </summary>
public interface IPermissionRepository : IGenericRepository<Permission, PermissionFilter>
{
}
