using Microsoft.Extensions.Logging;
using Volcanion.Core.Services.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Services.Implementations;

/// <inheritdoc />
internal class GrantPermissionService : BaseService<GrantPermission, IGrantPermissionRepository, GrantPermissionFilter>, IGrantPermissionService
{
    public GrantPermissionService(IGrantPermissionRepository repository, ILogger<BaseService<GrantPermission, IGrantPermissionRepository, GrantPermissionFilter>> logger) : base(repository, logger)
    {
    }
}
