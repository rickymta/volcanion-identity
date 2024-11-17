using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Volcanion.Core.Infrastructure.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Context;
using Volcanion.Identity.Models.Entities;

namespace Volcanion.Identity.Infrastructure.Implementations;

/// <inheritdoc />
internal class RolePermissionRepository(ApplicationDbContext context, ILogger<BaseRepository<RolePermission, ApplicationDbContext>> logger) : BaseRepository<RolePermission, ApplicationDbContext>(context, logger), IRolePermissionRepository
{
    /// <inheritdoc />
    public async Task<List<RolePermission>?> GetRolePermissionByGrantPermissionId(Guid grantPermissionId)
    {
    //    var rolePermissions = await _context.RolePermissions
    //.Where(x => x.Id == grantPermissionId)
    //.Select(x => new 
    //{
    //    x.Id,
    //    Role = new { x.Role.Id, x.Role.Name },
    //    Permission = new { x.Permission.Id, x.Permission.Name }
    //})
    //.ToListAsync();

        return await _context.RolePermissions
            .Include(x => x.Role)
            .Include(x => x.Permission)
            .AsNoTracking()
            .Where(x => x.Id == grantPermissionId)
            .ToListAsync();
    }
}
