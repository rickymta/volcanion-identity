using Volcanion.Core.Handlers.Abstractions;
using Volcanion.Core.Models.Common;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;

namespace Volcanion.Identity.Handlers.Abstractions;

/// <summary>
/// IAccountHandler
/// </summary>
public interface IAccountHandler : IBaseHandler<Account>
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
    /// <returns></returns>
    Task<DataPaging<Account>> FilterDataPagingAsync(AccountFilter filter);
}
