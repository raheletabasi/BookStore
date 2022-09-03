using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RolePermissionController : ControllerBase
{
    private readonly IRolePermissionService _rolePermissionService;

    public RolePermissionController(IRolePermissionService rolePermissionService)
    {
        _rolePermissionService = rolePermissionService;
    }

    [HttpPost("AddRolePermission")]
    public async Task<IActionResult> AddRolePermission(RolePermissionViewModel rolePermissionViewModel)
    {
        var result = await _rolePermissionService.AddRolePermission(rolePermissionViewModel);

        if (result == ResultRolePermission.duplicate) return BadRequest("Role Permission Is Duplicate");

        if (result == ResultRolePermission.Error) return BadRequest("Error In Add RolePermission");

        return Ok("Success");
    }

    [HttpDelete("DeleteRolePermission")]
    public async Task<IActionResult> DeleteRolePermission(Guid id)
    {
        var result = await _rolePermissionService.DeleteRolePermission(id);

        if (result == ResultRolePermission.notFound) return BadRequest("Role Permission Is No Found");

        if (result == ResultRolePermission.Error) return BadRequest("Error In Delete Role Permission");

        return Ok("Success");
    }

    [HttpGet("GetAllRolePermissions")]
    public IActionResult GetAllRolePermissions()
    {
        var result = _rolePermissionService.GetAllRolePermission();
        return Ok(result);
    }

    [HttpGet("GetRolePermissionById")]
    public async Task<IActionResult> GetRolePermissionById(Guid id)
    {
        var result = await _rolePermissionService.GetRolePermissionbyRoleId(id);
        return Ok(result);
    }

    [HttpPut("UpdateRolePermission")]
    public async Task<IActionResult> UpdateRolePermission(RolePermissionViewModel rolePermissionViewModel)
    {
        var result = await _rolePermissionService.UpdateRolePermission(rolePermissionViewModel);

        if (result == ResultRolePermission.duplicate) return BadRequest("Role Permission Is Duplicate");

        if (result == ResultRolePermission.notFound) return BadRequest("Role Permission Is No Found");

        if (result == ResultRolePermission.Error) return BadRequest("Error In Update Role Permission");

        return Ok("Success");
    }
}
