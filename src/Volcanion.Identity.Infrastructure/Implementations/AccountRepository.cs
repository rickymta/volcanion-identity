using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Volcanion.Core.Infrastructure.Implementations;
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
    public AccountRepository(ApplicationDbContext context, ILogger<BaseRepository<Account, ApplicationDbContext>> logger) : base(context, logger)
    {
    }

    /// <inheritdoc/>
    public async Task<Account?> GetAccountByEmail(string email)
    {
        var account = await _context.Account.FirstOrDefaultAsync(x => x.Email.Equals(email));
        return account;
    }
}
