using Microsoft.Extensions.Logging;
using Volcanion_Core_Handlers.Implementations;
using Volcanion_Identity_Handlers.Abstractions;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Services.Abstractions;

namespace Volcanion_Identity_Handlers.Implementations;

/// <inheritdoc/>
internal class RolePermissionHandler : BaseHandler<RolePermission, IRolePermissionService>, IRolePermissionHandler
{
    /// <inheritdoc/>
    public RolePermissionHandler(IRolePermissionService service, ILogger<BaseHandler<RolePermission, IRolePermissionService>> logger) : base(service, logger)
    {
    }
}
