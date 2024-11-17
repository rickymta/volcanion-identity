using Microsoft.Extensions.Logging;
using Volcanion.Core.Handlers.Implementations;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;
using Volcanion.Identity.Models.Request;
using Volcanion.Identity.Models.Response;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Handlers.Implementations;

/// <inheritdoc/>
internal class AccountHandler : BaseHandler<Account, IAccountService, AccountFilter>, IAccountHandler
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="service"></param>
    /// <param name="logger"></param>
    public AccountHandler(IAccountService service, ILogger<BaseHandler<Account, IAccountService, AccountFilter>> logger) : base(service, logger)
    {
    }

    /// <inheritdoc/>
    public async Task<AccountResponse?> Login(AccountLogin account)
    {
        return await _service.Login(account);
    }

    /// <inheritdoc/>
    public async Task<AccountResponse?> RefreshToken(TokenRequest request)
    {
        return await _service.RefreshToken(request);
    }

    /// <inheritdoc/>
    public async Task<AccountResponse?> Register(AccountRegister account)
    {
        return await _service.Register(account);
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAccountAsync(Account account)
    {
        return await _service.UpdateAccountAsync(account);
    }
}
