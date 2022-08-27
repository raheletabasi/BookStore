using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpPost("AddPermission")]
    public async Task<IActionResult> AddPermission(PermissionViewModel permissionViewModel)
    {
        var result = await _permissionService.AddPermission(permissionViewModel);

        if (result == ResultPermission.duplicate) return BadRequest("Permission Is Duplicate");

        if (result == ResultPermission.Error) return BadRequest("Error In Add Permission");

        return Ok("Success");
    }

    [HttpDelete("DeletePermission")]
    public async Task<IActionResult> DeletePermission(Guid id)
    {
        var result = await _permissionService.DeletePermission(id);

        if (result == ResultPermission.notFound) return BadRequest("Permission Is No Found");

        if (result == ResultPermission.Error) return BadRequest("Error In Delete Permission");

        return Ok("Success");
    }

    [HttpGet("GetAllChildByPermissionId")]
    public async Task<IActionResult> GetAllChildByPermissionId(Guid id)
    {
        var result = await _permissionService.GetAllChildByPermissionId(id);
        return Ok(result);
    }

    [HttpGet("GetAllPermission")]
    public async Task<IActionResult> GetAllPermission()
    {
        var result = await _permissionService.GetAllPermission();
        return Ok(result);
    }

    [HttpGet("GetPermissionById")]
    public async Task<IActionResult> GetPermissionById(Guid id)
    {
        var result = await _permissionService.GetPermissionById(id);
        return Ok(result);
    }

    [HttpPut("UpdatePermission")]
    public async Task<IActionResult> UpdatePermission(PermissionViewModel permissionViewModel)
    {
        var result = await _permissionService.UpdatePermission(permissionViewModel);

        if (result == ResultPermission.duplicate) return BadRequest("Permission Is Duplicate");

        if (result == ResultPermission.notFound) return BadRequest("Permission Is No Found");

        if (result == ResultPermission.Error) return BadRequest("Error In Update Permission");

        return Ok("Success");
    }
}
