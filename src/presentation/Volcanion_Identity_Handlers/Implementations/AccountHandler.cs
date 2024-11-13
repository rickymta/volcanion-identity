using Microsoft.Extensions.Logging;
using Volcanion_Core_Handlers.Implementations;
using Volcanion_Identity_Handlers.Abstractions;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Models.Request;
using Volcanion_Identity_Models.Response;
using Volcanion_Identity_Services.Abstractions;

namespace Volcanion_Identity_Handlers.Implementations;

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
}
