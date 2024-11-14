using Microsoft.Extensions.Logging;
using Volcanion.Core.Services.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Services.Implementations;

/// <inheritdoc />
internal class RoleService : BaseService<Role, IRoleRepository>, IRoleService
{
    public RoleService(IRoleRepository repository, ILogger<BaseService<Role, IRoleRepository>> logger) : base(repository, logger)
    {
    }
}
