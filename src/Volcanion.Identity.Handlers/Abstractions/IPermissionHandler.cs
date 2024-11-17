using Volcanion.Core.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;

namespace Volcanion.Identity.Handlers.Abstractions;

/// <summary>
/// IPermissionHandler
/// </summary>
public interface IPermissionHandler : IBaseHandler<Permission, PermissionFilter>
{
}
