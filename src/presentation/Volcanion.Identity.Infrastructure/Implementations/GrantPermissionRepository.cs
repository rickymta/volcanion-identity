using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Volcanion.Core.Infrastructure.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Context;
using Volcanion.Identity.Models.Entities;

namespace Volcanion.Identity.Infrastructure.Implementations;

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
