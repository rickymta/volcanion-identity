using Microsoft.Extensions.Logging;
using Volcanion_Core_Infrastructure.Implementations;
using Volcanion_Identity_Infrastructure.Abstractions;
using Volcanion_Identity_Models.Context;
using Volcanion_Identity_Models.Entities;

namespace Volcanion_Identity_Infrastructure.Implementations;

internal class RolePermissionRepository : BaseRepository<RolePermission, ApplicationDbContext>, IRolePermissionRepository
{
    public RolePermissionRepository(ApplicationDbContext context, ILogger<BaseRepository<RolePermission, ApplicationDbContext>> logger) : base(context, logger)
    {
    }
}
