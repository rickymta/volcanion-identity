using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Volcanion_Core_Infrastructure.Implementations;
using Volcanion_Identity_Infrastructure.Abstractions;
using Volcanion_Identity_Models.Context;
using Volcanion_Identity_Models.Entities;

namespace Volcanion_Identity_Infrastructure.Implementations;

/// <inheritdoc/>
internal class GrantPermissionRepository : BaseRepository<GrantPermission, ApplicationDbContext>, IGrantPermissionRepository
{
    public GrantPermissionRepository(ApplicationDbContext context, ILogger<BaseRepository<GrantPermission, ApplicationDbContext>> logger) : base(context, logger)
    {
    }

    /// <inheritdoc/>
    public async Task<GrantPermission?> GetGrantPermissionByAccountId(Guid accountId)
    {
        return await _context.GrantPermissions.Include(x => x.RolePermissions).FirstOrDefaultAsync(x => x.AccountId == accountId);
    }
}
