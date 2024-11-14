using Volcanion.Core.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;

namespace Volcanion.Identity.Infrastructure.Abstractions;

/// <summary>
/// IGrantPermissionRepository
/// </summary>
public interface IGrantPermissionRepository : IGenericRepository<GrantPermission>
{
    /// <summary>
    /// GetGrantPermissionByAccountId
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    Task<GrantPermission?> GetGrantPermissionByAccountId(Guid accountId);
}
