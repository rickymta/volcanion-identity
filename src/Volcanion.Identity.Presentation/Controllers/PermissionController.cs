﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Volcanion.Core.Presentation.Controllers;
using Volcanion.Identity.Handlers.Abstractions;
using Volcanion.Identity.Models.Entities;
using Volcanion.Identity.Models.Request.DTOs;
using Volcanion.Identity.Models.Response.BOs;

namespace Volcanion.Identity.Presentation.Controllers;

/// <summary>
/// PermissionController
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class PermissionController : BaseController
{
    /// <summary>
    /// IPermissionHandler instance
    /// </summary>
    private readonly IPermissionHandler _permissionHandler;

    /// <summary>
    /// IMapper instance
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="permissionHandler"></param>
    /// <param name="mapper"></param>
    public PermissionController(IPermissionHandler permissionHandler, IMapper mapper)
    {
        _permissionHandler = permissionHandler;
        _mapper = mapper;
    }

    /// <summary>
    /// CreateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(PermissionRequestDTO request)
    {
        var permission = _mapper.Map<Permission>(request);
        var result = await _permissionHandler.CreateAsync(permission);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// UpdateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(PermissionRequestDTO request)
    {
        var permission = _mapper.Map<Permission>(request);
        var result = await _permissionHandler.UpdateAsync(permission);
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
        var result = await _permissionHandler.DeleteAsync(id);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _permissionHandler.GetAllAsync();
        var data = _mapper.Map<IEnumerable<PermissionResponseBO>>(result);
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
        var result = await _permissionHandler.GetAsync(id);
        var data = _mapper.Map<PermissionResponseBO>(result);
        return Ok(SuccessData(data));
    }
}
