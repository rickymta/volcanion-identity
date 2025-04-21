using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using Volcanion.Core.Handlers.Implementations;
using Volcanion.Core.Models.Common;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Handlers.Implementations;

/// <inheritdoc/>
internal class AccountHandler : BaseHandler<Account, IAccountService>, IAccountHandler
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="service"></param>
    /// <param name="logger"></param>
    public AccountHandler(IAccountService service, ILogger<BaseHandler<Account, IAccountService>> logger) : base(service, logger)
    {
    }

    /// <inheritdoc/>
    public async Task<DataPaging<Account>> FilterDataPagingAsync(AccountFilter filter)
    {
        // Declare default expression
        Expression<Func<Account, bool>> expression = x => true;
        // Declare filters
        var filters = new List<Expression<Func<Account, bool>>>();

        // Check if filter by email is not null or empty then add to filters
        if (!string.IsNullOrEmpty(filter.Email))
        {
            filters.Add(x => x.Email.Contains(filter.Email));
        }

        // Check if filter by fullname is not null or empty then add to filters
        if (!string.IsNullOrEmpty(filter.Fullname))
        {
            filters.Add(x => x.Fullname.Contains(filter.Fullname));
        }

        // Check if filter by address is not null or empty then add to filters
        if (!string.IsNullOrEmpty(filter.Address))
        {
            filters.Add(x => x.Address!.Contains(filter.Address));
        }

        // Check if filter by phone number is not null or empty then add to filters
        if (!string.IsNullOrEmpty(filter.PhoneNumber))
        {
            filters.Add(x => x.PhoneNumber!.Contains(filter.PhoneNumber));
        }

        // Get all filters and combine them
        foreach (var filterExpression in filters)
        {
            expression = Expression.Lambda<Func<Account, bool>>(Expression.AndAlso(expression.Body, filterExpression.Body), expression.Parameters);
        }

        // Return data paging
        return await _service.FilterDataPagingAsync(filter, expression);
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAccountAsync(Account account)
    {
        return await _service.UpdateAccountAsync(account);
    }
}
