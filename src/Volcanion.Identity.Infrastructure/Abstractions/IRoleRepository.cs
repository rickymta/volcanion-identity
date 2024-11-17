using Volcanion.Core.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;

namespace Volcanion.Identity.Infrastructure.Abstractions;

/// <summary>
/// IRoleRepository
/// </summary>
public interface IRoleRepository : IGenericRepository<Role, RoleFilter>
{
}
