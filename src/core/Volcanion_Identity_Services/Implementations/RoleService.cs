using Microsoft.Extensions.Logging;
using Volcanion_Core_Services.Implementations;
using Volcanion_Identity_Infrastructure.Abstractions;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Services.Abstractions;

namespace Volcanion_Identity_Services.Implementations;

/// <inheritdoc />
internal class RoleService : BaseService<Role, IRoleRepository>, IRoleService
{
    public RoleService(IRoleRepository repository, ILogger<BaseService<Role, IRoleRepository>> logger) : base(repository, logger)
    {
    }
}
