using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Volcanion.Core.Models.Attributes;
using Volcanion.Core.Presentation.Controllers;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Request.DTOs;
using Volcanion.Identity.Models.Response.BOs;

namespace Volcanion.Identity.Presentation.Controllers;

/// <summary>
/// AccountController
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[VolcanionAuth(["Account.*"])]
public class AccountController : BaseController
{
    /// <summary>
    /// IAccountHandler instance
    /// </summary>
    private readonly IAccountHandler _accountHandler;

    /// <summary>
    /// IMapper instance
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="AccountHandler"></param>
    /// <param name="mapper"></param>
    public AccountController(IAccountHandler AccountHandler, IMapper mapper)
    {
        _accountHandler = AccountHandler;
        _mapper = mapper;
    }

    /// <summary>
    /// CreateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [VolcanionAuth(["Account.All", "Account.Create"])]
    public async Task<IActionResult> CreateAsync(AccountRequestDTO request)
    {
        var Account = _mapper.Map<Account>(request);
        var result = await _accountHandler.CreateAsync(Account);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// UpdateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [VolcanionAuth(["Account.All", "Account.Update"])]
    public async Task<IActionResult> UpdateAsync(AccountRequestDTO request)
    {
        var Account = _mapper.Map<Account>(request);
        var result = await _accountHandler.UpdateAsync(Account);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// DeleteAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [VolcanionAuth(["Account.All", "Account.Delete"])]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _accountHandler.DeleteAsync(id);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [VolcanionAuth(["Account.All", "Account.GetAll"])]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _accountHandler.GetAllAsync();
        var data = _mapper.Map<IEnumerable<AccountResponseBO>>(result);
        return Ok(SuccessData(data));
    }

    /// <summary>
    /// GetByIdAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [VolcanionAuth(["Account.All", "Account.GetOne"])]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountHandler.GetAsync(id);
        var data = _mapper.Map<AccountResponseBO>(result);
        return Ok(SuccessData(data));
    }
}
