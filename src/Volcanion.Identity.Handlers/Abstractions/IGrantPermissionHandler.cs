using Volcanion.Core.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;

namespace Volcanion.Identity.Handlers.Abstractions;

/// <summary>
/// IGrantPermissionHandler
/// </summary>
public interface IGrantPermissionHandler : IBaseHandler<GrantPermission, GrantPermissionFilter>
{
}
