using Volcanion.Core.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;

namespace Volcanion.Identity.Infrastructure.Abstractions;

/// <summary>
/// IAccountRepository
/// </summary>
public interface IAccountRepository : IGenericRepository<Account, AccountFilter>
{
    /// <summary>
    /// GetAccountByEmail
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<Account?> GetAccountByEmail(string email);
}
