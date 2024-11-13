using Microsoft.Extensions.Logging;
using Volcanion_Core_Services.Implementations;
using Volcanion_Identity_Infrastructure.Abstractions;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Services.Abstractions;

namespace Volcanion_Identity_Services.Implementations;

/// <inheritdoc />
internal class GrantPermissionService : BaseService<GrantPermission, IGrantPermissionRepository>, IGrantPermissionService
{
    public GrantPermissionService(IGrantPermissionRepository repository, ILogger<BaseService<GrantPermission, IGrantPermissionRepository>> logger) : base(repository, logger)
    {
    }
}
