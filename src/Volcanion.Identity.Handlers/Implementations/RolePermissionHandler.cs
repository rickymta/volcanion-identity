using Microsoft.Extensions.Logging;
using Volcanion.Core.Handlers.Implementations;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Handlers.Implementations;

/// <inheritdoc/>
internal class RolePermissionHandler : BaseHandler<RolePermission, IRolePermissionService, RolePermissionFilter>, IRolePermissionHandler
{
    /// <inheritdoc/>
    public RolePermissionHandler(IRolePermissionService service, ILogger<BaseHandler<RolePermission, IRolePermissionService, RolePermissionFilter>> logger) : base(service, logger)
    {
    }
}
