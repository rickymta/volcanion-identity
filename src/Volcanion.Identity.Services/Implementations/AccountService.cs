using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using Volcanion.Core.Common.Abstractions;
using Volcanion.Core.Models.Common;
using Volcanion.Core.Models.Enums;
using Volcanion.Core.Models.Filter;
using Volcanion.Core.Models.Jwt;
using Volcanion.Core.Presentation.Middlewares.Exceptions;
using Volcanion.Core.Services.Implementations;
using Volcanion.Identity.Infrastructure.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Request;
using Volcanion.Identity.Models.Response;
using Volcanion.Identity.Models.Setting;
using Volcanion.Identity.Services.Abstractions;

namespace Volcanion.Identity.Services.Implementations;

/// <inheritdoc />
internal class AccountService : BaseService<Account, IAccountRepository>, IAccountService
{

    /// <summary>
    /// IHttpContextAccessor
    /// </summary>
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// IHahsProvider instance
    /// </summary>
    private readonly IHashProvider _hashProvider;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="logger"></param>
    /// <param name="hashProvider"></param>
    public AccountService(IAccountRepository repository, ILogger<BaseService<Account, IAccountRepository>> logger, IHashProvider hashProvider, IHttpContextAccessor httpContextAccessor) : base(repository, logger)
    {
        _hashProvider = hashProvider;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc />
    public async Task<bool> UpdateAccountAsync(Account account)
    {
        var routeData = _httpContextAccessor.HttpContext.GetRouteData().Values;
        var accountFind = await _repository.GetAsync(account.Id);
        if (accountFind == null) return false;
        account.Password = string.IsNullOrEmpty(account.Password) ? accountFind.Password : _hashProvider.HashPassword(account.Password);

        if (account.IsActived != accountFind.IsActived)
        {
            if (!account.IsActived)
            {
                account.IsDeleted = true;
                account.DeletedAt = DateTimeOffset.Now;
                account.DeletedBy = routeData["AccountId"].ToString();
            }
            else
            {
                account.IsDeleted = false;
                account.DeletedAt = null;
                account.DeletedBy = null;
            }
        }

        return await _repository.UpdateAsync(account);
    }

    /// <inheritdoc />
    public async Task<DataPaging<Account>> FilterDataPagingAsync(FilterBase filter, Expression<Func<Account, bool>> expression)
    {
        return await _repository.FilterDataPagingAsync(filter, expression);
    }
}
