using Microsoft.Extensions.Logging;
using Volcanion.Core.Services.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Services.Implementations;

/// <inheritdoc />
internal class RolePermissionService : BaseService<RolePermission, IRolePermissionRepository>, IRolePermissionService
{
    public RolePermissionService(IRolePermissionRepository repository, ILogger<BaseService<RolePermission, IRolePermissionRepository>> logger) : base(repository, logger)
    {
    }
}
