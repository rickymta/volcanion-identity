using Microsoft.Extensions.Logging;
using Volcanion_Core_Handlers.Implementations;
using Volcanion_Identity_Handlers.Abstractions;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Services.Abstractions;

namespace Volcanion_Identity_Handlers.Implementations;

/// <inheritdoc/>
internal class PermissionHandler : BaseHandler<Permission, IPermissionService>, IPermissionHandler
{
    /// <inheritdoc/>
    public PermissionHandler(IPermissionService service, ILogger<BaseHandler<Permission, IPermissionService>> logger) : base(service, logger)
    {
    }
}
