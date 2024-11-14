using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Volcanion.Core.Presentation.Controllers;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Request.DTOs;
using Volcanion.Identity.Models.Response.BOs;

namespace Volcanion.Identity.Presentation.Controllers;

/// <summary>
/// RoleController
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class RoleController : BaseController
{
    /// <summary>
    /// IRoleHandler instance
    /// </summary>
    private readonly IRoleHandler _roleHandler;

    /// <summary>
    /// IMapper instance
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="roleHandler"></param>
    /// <param name="mapper"></param>
    public RoleController(IRoleHandler roleHandler, IMapper mapper)
    {
        _roleHandler = roleHandler;
        _mapper = mapper;
    }

    /// <summary>
    /// CreateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(RoleRequestDTO request)
    {
        var role = _mapper.Map<Role>(request);
        var result = await _roleHandler.CreateAsync(role);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// UpdateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(RoleRequestDTO request)
    {
        var role = _mapper.Map<Role>(request);
        var result = await _roleHandler.UpdateAsync(role);
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
        var result = await _roleHandler.DeleteAsync(id);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _roleHandler.GetAllAsync();
        var data = _mapper.Map<IEnumerable<RoleResponseBO>>(result);
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
        var result = await _roleHandler.GetAsync(id);
        var data = _mapper.Map<RoleResponseBO>(result);
        return Ok(SuccessData(data));
    }
}
