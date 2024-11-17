using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Volcanion.Core.Infrastructure.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Context;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Response.BOs;

namespace Volcanion.Identity.Infrastructure.Implementations;

/// <inheritdoc/>
internal class GrantPermissionRepository(ApplicationDbContext context, ILogger<BaseRepository<GrantPermission, ApplicationDbContext>> logger) : BaseRepository<GrantPermission, ApplicationDbContext>(context, logger), IGrantPermissionRepository
{
    /// <inheritdoc/>
    public async Task<List<GrantPermissionResponseBO>?> GetGrantPermissionByAccountId(Guid accountId)
    {
        var result = await _context.Database
            .SqlQueryRaw<GrantPermissionResponseBO>(@"
                select
                gp.Id Id, a.Id AccountId ,r.Id RoleId , r.Name RoleName, p.Id PermissionId , p.Name PermissionName, rp.Id RolePermissionId
                from
                Account a 
                inner join GrantPermissions gp on a.Id = gp.AccountId 
                inner join RolePermissions rp on gp.RolePermissionId = rp.Id
                inner join Roles r on r.Id = rp.RoleId
                inner join Permissions p on p.Id = rp.PermissionId
                WHERE gp.AccountId = {0}", accountId)
            .ToListAsync();

        return result;
    }
}
