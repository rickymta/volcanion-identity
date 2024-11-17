using Microsoft.Extensions.Logging;
using Volcanion.Core.Services.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Services.Implementations;

/// <inheritdoc />
internal class RoleService : BaseService<Role, IRoleRepository, RoleFilter>, IRoleService
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="logger"></param>
    public RoleService(IRoleRepository repository, ILogger<BaseService<Role, IRoleRepository, RoleFilter>> logger) : base(repository, logger)
    {
    }
}
