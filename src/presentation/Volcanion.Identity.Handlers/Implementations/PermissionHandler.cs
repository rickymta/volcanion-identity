using Microsoft.Extensions.Logging;
using Volcanion.Core.Handlers.Implementations;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Handlers.Implementations;

/// <inheritdoc/>
internal class PermissionHandler : BaseHandler<Permission, IPermissionService>, IPermissionHandler
{
    /// <inheritdoc/>
    public PermissionHandler(IPermissionService service, ILogger<BaseHandler<Permission, IPermissionService>> logger) : base(service, logger)
    {
    }
}
