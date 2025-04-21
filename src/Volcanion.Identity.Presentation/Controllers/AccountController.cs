using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Volcanion.Core.Common.Abstractions;
using Volcanion.Core.Models.Attributes;
using Volcanion.Core.Presentation.Controllers;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Filters;
using Volcanion.Identity.Models.Request.DTOs;
using Volcanion.Identity.Models.Response.BOs;

namespace Volcanion.Identity.Presentation.Controllers;

/// <summary>
/// AccountController
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class AccountController : BaseController
{
    /// <summary>
    /// IAccountHandler instance
    /// </summary>
    private readonly IAccountHandler _accountHandler;

    /// <summary>
    /// IHashProvider instance
    /// </summary>
    private readonly IHashProvider _hashProvider;

    /// <summary>
    /// IMapper instance
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="accountHandler"></param>
    /// <param name="hashProvider"></param>
    /// <param name="mapper"></param>
    public AccountController(IAccountHandler accountHandler, IHashProvider hashProvider, IMapper mapper)
    {
        _accountHandler = accountHandler;
        _hashProvider = hashProvider;
        _mapper = mapper;
    }

    /// <summary>
    /// CreateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("create")]
    [VolcanionAuth(["Account.All", "Account.Create"])]
    public async Task<IActionResult> CreateAsync(AccountRequestDTO request)
    {
        var account = _mapper.Map<Account>(request);
        account.Password = _hashProvider.HashPassword(request.Password);
        var result = await _accountHandler.CreateAsync(account);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// UpdateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("update")]
    [VolcanionAuth(["Account.All", "Account.Update"])]
    public async Task<IActionResult> UpdateAsync(AccountRequestDTO request)
    {
        var account = _mapper.Map<Account>(request);
        var result = await _accountHandler.UpdateAccountAsync(account);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// DeleteAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("soft-delete")]
    [VolcanionAuth(["Account.All", "Account.SoftDelete"])]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _accountHandler.SoftDeleteAsync(id);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// HardDeleteAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("hard-delete")]
    [VolcanionAuth(["Account.All", "Account.HardDelete"])]
    public async Task<IActionResult> HardDeleteAsync(Guid id)
    {
        var result = await _accountHandler.DeleteAsync(id);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// FilterDataPagingAsync
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet("filter")]
    [VolcanionAuth(["Account.All", "Account.Read"])]
    public async Task<IActionResult> FilterDataPagingAsync(AccountFilter filter)
    {
        var result = await _accountHandler.FilterDataPagingAsync(filter);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-all")]
    [VolcanionAuth(["Account.All", "Account.GetAll"])]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _accountHandler.GetAllAsync();
        var accounts = _mapper.Map<IEnumerable<AccountResponseBO>>(result);
        return Ok(SuccessData(accounts));
    }

    /// <summary>
    /// GetByIdAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("get-by-id")]
    [VolcanionAuth(["Account.All", "Account.GetOne"])]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountHandler.GetAsync(id);
        var account = _mapper.Map<AccountResponseBO>(result);
        return Ok(SuccessData(account));
    }
}
