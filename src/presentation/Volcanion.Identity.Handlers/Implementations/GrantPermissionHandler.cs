using Microsoft.Extensions.Logging;
using Volcanion.Core.Handlers.Implementations;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Handlers.Implementations;

/// <inheritdoc/>
internal class GrantPermissionHandler : BaseHandler<GrantPermission, IGrantPermissionService>, IGrantPermissionHandler
{
    /// <inheritdoc/>
    public GrantPermissionHandler(IGrantPermissionService service, ILogger<BaseHandler<GrantPermission, IGrantPermissionService>> logger) : base(service, logger)
    {
    }
}
