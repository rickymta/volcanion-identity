using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Volcanion.Core.Infrastructure.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Context;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;

namespace Volcanion.Identity.Infrastructure.Implementations;

/// <inheritdoc/>
internal class PermissionRepository : BaseRepository<Permission, ApplicationDbContext, PermissionFilter>, IPermissionRepository
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="logger"></param>
    /// <param name="httpContextAccessor"></param>
    public PermissionRepository(ApplicationDbContext context, ILogger<BaseRepository<Permission, ApplicationDbContext, PermissionFilter>> logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
    {
    }
}
