using Microsoft.Extensions.Logging;
using Volcanion.Core.Handlers.Implementations;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Handlers.Implementations;

/// <inheritdoc/>
internal class PermissionHandler : BaseHandler<Permission, IPermissionService, PermissionFilter>, IPermissionHandler
{
    /// <inheritdoc/>
    public PermissionHandler(IPermissionService service, ILogger<BaseHandler<Permission, IPermissionService, PermissionFilter>> logger) : base(service, logger)
    {
    }
}
