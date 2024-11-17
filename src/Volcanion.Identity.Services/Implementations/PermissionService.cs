using Microsoft.Extensions.Logging;
using Volcanion.Core.Services.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Services.Implementations;

/// <inheritdoc />
internal class PermissionService : BaseService<Permission, IPermissionRepository, PermissionFilter>, IPermissionService
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="logger"></param>
    public PermissionService(IPermissionRepository repository, ILogger<BaseService<Permission, IPermissionRepository, PermissionFilter>> logger) : base(repository, logger)
    {
    }
}
