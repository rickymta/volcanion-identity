using Microsoft.Extensions.Logging;
using Volcanion_Core_Handlers.Implementations;
using Volcanion_Identity_Handlers.Abstractions;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Services.Abstractions;

namespace Volcanion_Identity_Handlers.Implementations;

/// <inheritdoc/>
internal class RoleHandler : BaseHandler<Role, IRoleService>, IRoleHandler
{
    /// <inheritdoc/>
    public RoleHandler(IRoleService service, ILogger<BaseHandler<Role, IRoleService>> logger) : base(service, logger)
    {
    }
}
