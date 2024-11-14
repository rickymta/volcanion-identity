using Microsoft.Extensions.Logging;
using Volcanion.Core.Handlers.Implementations;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Handlers.Implementations;

/// <inheritdoc/>
internal class RoleHandler : BaseHandler<Role, IRoleService>, IRoleHandler
{
    /// <inheritdoc/>
    public RoleHandler(IRoleService service, ILogger<BaseHandler<Role, IRoleService>> logger) : base(service, logger)
    {
    }
}
