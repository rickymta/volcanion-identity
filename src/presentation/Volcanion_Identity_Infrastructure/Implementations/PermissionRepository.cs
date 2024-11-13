using Microsoft.Extensions.Logging;
using Volcanion_Core_Infrastructure.Implementations;
using Volcanion_Identity_Infrastructure.Abstractions;
using Volcanion_Identity_Models.Context;
using Volcanion_Identity_Models.Entities;

namespace Volcanion_Identity_Infrastructure.Implementations;

internal class PermissionRepository : BaseRepository<Permission, ApplicationDbContext>, IPermissionRepository
{
    public PermissionRepository(ApplicationDbContext context, ILogger<BaseRepository<Permission, ApplicationDbContext>> logger) : base(context, logger)
    {
    }
}
