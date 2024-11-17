using Microsoft.Extensions.Logging;
using Volcanion.Core.Handlers.Implementations;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Handlers.Implementations;

/// <inheritdoc/>
internal class RoleHandler : BaseHandler<Role, IRoleService, RoleFilter>, IRoleHandler
{
    /// <inheritdoc/>
    public RoleHandler(IRoleService service, ILogger<BaseHandler<Role, IRoleService, RoleFilter>> logger) : base(service, logger)
    {
    }
}
