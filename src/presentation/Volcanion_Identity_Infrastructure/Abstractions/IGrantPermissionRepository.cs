using Volcanion_Core_Infrastructure.Abstractions;
using Volcanion_Identity_Models.Entities;

namespace Volcanion_Identity_Infrastructure.Abstractions;

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
