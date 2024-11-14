using Microsoft.Extensions.Logging;
using Volcanion.Core.Services.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Services.Implementations;

/// <inheritdoc />
internal class PermissionService : BaseService<Permission, IPermissionRepository>, IPermissionService
{
    public PermissionService(IPermissionRepository repository, ILogger<BaseService<Permission, IPermissionRepository>> logger) : base(repository, logger)
    {
    }
}
