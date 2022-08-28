using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost("AddRole")]
    public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
    {
        var result = await _roleService.AddRole(roleViewModel);

        if (result == ResultRole.duplicate) return BadRequest("Role Is Duplicate");

        if (result == ResultRole.Error) return BadRequest("Error In Add");

        return Ok("Success");
    }

    [HttpDelete("DeleteRole")]
    public async Task<IActionResult> DeleteRole(Guid id)
    {
        var result = await _roleService.DeleteRole(id);

        if (result == ResultRole.notFound) return BadRequest("Role Is No Found");

        if (result == ResultRole.Error) return BadRequest("Error In Delete Role");

        return Ok("Success");
    }

    [HttpGet("GetAllRoles")]
    public async Task<IActionResult> GetAllRoles()
    {
        var result = await _roleService.GetAllRoles();
        return Ok(result);
    }

    [HttpGet("GetRoleById")]
    public async Task<IActionResult> GetRoleById(Guid id)
    {
        var result = await _roleService.GetRolebyId(id);
        return Ok(result);
    }

    [HttpPut("UpdateRole")]
    public async Task<IActionResult> UpdateRole(RoleViewModel roleViewModel)
    {
        var result = await _roleService.UpdateRole(roleViewModel);

        if (result == ResultRole.duplicate) return BadRequest("Role Is Duplicate");

        if (result == ResultRole.notFound) return BadRequest("Role Is No Found");

        if (result == ResultRole.Error) return BadRequest("Error In Update Role");

        return Ok("Success");
    }
}
