using Volcanion.Core.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;

namespace Volcanion.Identity.Handlers.Abstractions;

/// <summary>
/// IRoleHandler
/// </summary>
public interface IRoleHandler : IBaseHandler<Role, RoleFilter>
{
}
