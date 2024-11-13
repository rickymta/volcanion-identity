using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Volcanion_Core_Presentation.Controllers;
using Volcanion_Identity_Handlers.Abstractions;
using Volcanion_Identity_Models.Entities;
using Volcanion_Identity_Models.Request.DTOs;
using Volcanion_Identity_Models.Response.BOs;

namespace Volcanion_Identity_Presentation.Controllers;

/// <summary>
/// GrantPermissionController
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class GrantPermissionController : BaseController
{
    /// <summary>
    /// IGrantPermissionHandler instance
    /// </summary>
    private readonly IGrantPermissionHandler _grantPermissionHandler;

    /// <summary>
    /// IMapper instance
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="GrantPermissionHandler"></param>
    /// <param name="mapper"></param>
    public GrantPermissionController(IGrantPermissionHandler GrantPermissionHandler, IMapper mapper)
    {
        _grantPermissionHandler = GrantPermissionHandler;
        _mapper = mapper;
    }

    /// <summary>
    /// CreateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(GrantPermissionRequestDTO request)
    {
        var GrantPermission = _mapper.Map<GrantPermission>(request);
        var result = await _grantPermissionHandler.CreateAsync(GrantPermission);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// UpdateAsync
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(GrantPermissionRequestDTO request)
    {
        var GrantPermission = _mapper.Map<GrantPermission>(request);
        var result = await _grantPermissionHandler.UpdateAsync(GrantPermission);
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
        var result = await _grantPermissionHandler.DeleteAsync(id);
        return Ok(SuccessData(result));
    }

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _grantPermissionHandler.GetAllAsync();
        var data = _mapper.Map<IEnumerable<GrantPermissionResponseBO>>(result);
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
        var result = await _grantPermissionHandler.GetAsync(id);
        var data = _mapper.Map<GrantPermissionResponseBO>(result);
        return Ok(SuccessData(data));
    }
}
