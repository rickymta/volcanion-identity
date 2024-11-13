using Volcanion_Core_Infrastructure.Abstractions;
using Volcanion_Identity_Models.Entities;

namespace Volcanion_Identity_Infrastructure.Abstractions;

public interface IAccountRepository : IGenericRepository<Account>
{
    /// <summary>
    /// GetAccountByEmail
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<Account?> GetAccountByEmail(string email);
}
