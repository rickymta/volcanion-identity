using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using Volcanion.Core.Infrastructure.Implementations;
using Volcanion.Core.Models.Common;
using Volcanion.Core.Models.Filter;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Context;
using Volcanion.Identity.Models.Entities;

namespace Volcanion.Identity.Infrastructure.Implementations;

/// <inheritdoc/>
internal class AccountRepository : BaseRepository<Account, ApplicationDbContext>, IAccountRepository
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="logger"></param>
    /// <param name="httpContextAccessor"></param>
    public AccountRepository(ApplicationDbContext context, ILogger<BaseRepository<Account, ApplicationDbContext>> logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
    {
    }

    /// <inheritdoc/>
    public async Task<DataPaging<Account>> FilterDataPagingAsync(FilterBase filter, Expression<Func<Account, bool>> expression)
    {
        var limit = filter.Limit ?? 20;
        var offset = (filter.Page ?? 1) - 1;
        var accounts = _context.Account.AsQueryable();

        if (expression != null)
        {
            accounts = accounts.Where(expression);
        }

        var total = accounts.Count();
        var data = await accounts.Skip(offset * limit).Take(limit).ToListAsync();

        var res =  new DataPaging<Account>
        {
            Data = data,
            PaginationCount = total
        };

        return res;
    }

    /// <inheritdoc/>
    public async Task<Account?> GetAccountByEmail(string email)
    {
        var account = await _context.Account.FirstOrDefaultAsync(x => x.Email.Equals(email));
        return account;
    }

    /// <inheritdoc/>
    public async Task<Account?> GetAccountByPhoneNumberAsync(string phoneNumber)
    {
        var account = await _context.Account.FirstOrDefaultAsync(x => x.PhoneNumber!.Equals(phoneNumber));
        return account;
    }
}
