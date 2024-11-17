using Volcanion.Core.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;

namespace Volcanion.Identity.Infrastructure.Abstractions;

/// <summary>
/// IRolePermissionRepository
/// </summary>
public interface IRolePermissionRepository : IGenericRepository<RolePermission>
{
    /// <summary>
    /// GetRolePermissionByGrantPermissionId
    /// </summary>
    /// <param name="grantPermissionId"></param>
    /// <returns></returns>
    Task<List<RolePermission>?> GetRolePermissionByGrantPermissionId(Guid grantPermissionId);
}
