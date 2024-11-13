using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Volcanion_Core_Presentation.Controllers;
using Volcanion_Identity_Handlers.Abstractions;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Models.Request.DTOs;
using Volcanion_Identity_Models.Response.BOs;

namespace Volcanion_Identity_Presentation.Controllers;

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
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _accountHandler.GetAsync(id);
        var data = _mapper.Map<AccountResponseBO>(result);
        return Ok(SuccessData(data));
    }
}
