using Microsoft.Extensions.Logging;
using Volcanion.Core.Services.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Services.Implementations;

/// <inheritdoc />
internal class RolePermissionService : BaseService<RolePermission, IRolePermissionRepository, RolePermissionFilter>, IRolePermissionService
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="logger"></param>
    public RolePermissionService(IRolePermissionRepository repository, ILogger<BaseService<RolePermission, IRolePermissionRepository, RolePermissionFilter>> logger) : base(repository, logger)
    {
    }
}
