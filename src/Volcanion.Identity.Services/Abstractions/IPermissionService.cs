using Volcanion.Core.Services.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;

namespace Volcanion.Identity.Services.Abstractions;

/// <inheritdoc />
public interface IPermissionService : IBaseService<Permission, PermissionFilter>
{
}
