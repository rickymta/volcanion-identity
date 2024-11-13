using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Volcanion.Core.Presentation.Controllers;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Request.DTOs;
using Volcanion.Identity.Models.Response.BOs;

namespace Volcanion.Identity.Presentation.Controllers;

/// <summary>
/// RolePermissionController
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class RolePermissionController : BaseController
{
    /// <summary>
    /// IRolePermissionHandler instance
    /// </summary>
    private readonly IRolePermissionHandler _rolePermissionHandler;

    /// <summary>
    /// IMapper instance
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="RolePermissionHandler"></param>
    /// <param name="mapper"></param>
    public RolePermissionController(IRolePermissionHandler RolePermissionHandler, IMapper mapper)
    {
        _rolePermissionHandler = RolePermissionHandler;
        _mapper = mapper;
    }

    /// <summary>
    /// CreateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(RolePermissionRequestDTO request)
    {
        var RolePermission = _mapper.Map<RolePermission>(request);
        var result = await _rolePermissionHandler.CreateAsync(RolePermission);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// UpdateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(RolePermissionRequestDTO request)
    {
        var RolePermission = _mapper.Map<RolePermission>(request);
        var result = await _rolePermissionHandler.UpdateAsync(RolePermission);
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
        var result = await _rolePermissionHandler.DeleteAsync(id);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _rolePermissionHandler.GetAllAsync();
        var data = _mapper.Map<IEnumerable<RolePermissionResponseBO>>(result);
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
        var result = await _rolePermissionHandler.GetAsync(id);
        var data = _mapper.Map<RolePermissionResponseBO>(result);
        return Ok(SuccessData(data));
    }
}
