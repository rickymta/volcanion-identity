using System.Linq.Expressions;
using Volcanion.Core.Models.Common;
using Volcanion.Core.Models.Filter;
using Volcanion.Core.Services.Abstractions;
using Volcanion.Identity.Models.Entities;

namespace Volcanion.Identity.Services.Abstractions;

/// <summary>
/// IAccountService
/// </summary>
public interface IAccountService : IBaseService<Account>
{
    /// <summary>
    /// UpdateAccountAsync
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    Task<bool> UpdateAccountAsync(Account account);

    /// <summary>
    /// FilterDataPagingAsync
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<DataPaging<Account>> FilterDataPagingAsync(FilterBase filter, Expression<Func<Account, bool>> expression);
}
