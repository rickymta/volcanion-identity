using Microsoft.Extensions.Logging;
using Volcanion_Core_Infrastructure.Implementations;
using Volcanion_Identity_Infrastructure.Abstractions;
using Volcanion_Identity_Models.Context;
using Volcanion_Identity_Models.Entities;

namespace Volcanion_Identity_Infrastructure.Implementations;

internal class RoleRepository : BaseRepository<Role, ApplicationDbContext>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context, ILogger<BaseRepository<Role, ApplicationDbContext>> logger) : base(context, logger)
    {
    }
}
