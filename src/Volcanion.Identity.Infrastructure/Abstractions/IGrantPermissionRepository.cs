using Volcanion.Core.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;
using Volcanion.Identity.Models.Response.BOs;

namespace Volcanion.Identity.Infrastructure.Abstractions;

/// <summary>
/// IGrantPermissionRepository
/// </summary>
public interface IGrantPermissionRepository : IGenericRepository<GrantPermission, GrantPermissionFilter>
{
    /// <summary>
    /// GetGrantPermissionByAccountId
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    Task<List<GrantPermissionResponseBO>?> GetGrantPermissionByAccountId(Guid accountId);
}
