using Microsoft.Extensions.Logging;
using Volcanion_Core_Services.Implementations;
using Volcanion_Identity_Infrastructure.Abstractions;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Services.Abstractions;

namespace Volcanion_Identity_Services.Implementations;

/// <inheritdoc />
internal class PermissionService : BaseService<Permission, IPermissionRepository>, IPermissionService
{
    public PermissionService(IPermissionRepository repository, ILogger<BaseService<Permission, IPermissionRepository>> logger) : base(repository, logger)
    {
    }
}
