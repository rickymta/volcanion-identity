using Microsoft.Extensions.Logging;
using Volcanion_Core_Handlers.Implementations;
using Volcanion_Identity_Handlers.Abstractions;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Services.Abstractions;

namespace Volcanion_Identity_Handlers.Implementations;

/// <inheritdoc/>
internal class GrantPermissionHandler : BaseHandler<GrantPermission, IGrantPermissionService>, IGrantPermissionHandler
{
    /// <inheritdoc/>
    public GrantPermissionHandler(IGrantPermissionService service, ILogger<BaseHandler<GrantPermission, IGrantPermissionService>> logger) : base(service, logger)
    {
    }
}
