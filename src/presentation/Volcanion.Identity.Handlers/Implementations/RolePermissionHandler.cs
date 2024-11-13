using Microsoft.Extensions.Logging;
using Volcanion.Core.Handlers.Implementations;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Handlers.Implementations;

/// <inheritdoc/>
internal class RolePermissionHandler : BaseHandler<RolePermission, IRolePermissionService>, IRolePermissionHandler
{
    /// <inheritdoc/>
    public RolePermissionHandler(IRolePermissionService service, ILogger<BaseHandler<RolePermission, IRolePermissionService>> logger) : base(service, logger)
    {
    }
}
