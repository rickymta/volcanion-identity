using System.Linq.Expressions;
using Volcanion.Core.Infrastructure.Abstractions;
using Volcanion.Core.Models.Common;
using Volcanion.Core.Models.Filter;
using Volcanion.Identity.Models.Entities;

namespace Volcanion.Identity.Infrastructure.Abstractions;

/// <summary>
/// IAccountRepository
/// </summary>
public interface IAccountRepository : IGenericRepository<Account>
{
    /// <summary>
    /// GetAccountByEmail
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<Account?> GetAccountByEmail(string email);

    /// <summary>
    /// GetAccountByPhoneNumberAsync
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    Task<Account?> GetAccountByPhoneNumberAsync(string phoneNumber);

    /// <summary>
    /// FilterDataPagingAsync
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<DataPaging<Account>> FilterDataPagingAsync(FilterBase filter, Expression<Func<Account, bool>> expression);
}
