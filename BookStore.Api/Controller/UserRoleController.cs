using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleService _userRoleService;

    public UserRoleController(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    [HttpPost("AddUserRole")]
    public async Task<IActionResult> AddUserRole(UserRoleViewModel userRoleViewModel)
    {
        var result = await _userRoleService.AddUserRole(userRoleViewModel);

        if (result == ResultUserRole.duplicate) return BadRequest("User Role Is Duplicate");

        if (result == ResultUserRole.Error) return BadRequest("Error In Add UserRole");

        return Ok("Success");
    }

    [HttpDelete("DeleteUserRole")]
    public async Task<IActionResult> DeleteUserRole(Guid id)
    {
        var result = await _userRoleService.DeleteUserRole(id);

        if (result == ResultUserRole.notFound) return BadRequest("UserRole Is No Found");

        if (result == ResultUserRole.Error) return BadRequest("Error In Delete UserRole");

        return Ok("Success");
    }

    [HttpGet("GetAllUserRole")]
    public async Task<IActionResult> GetAllUserRole()
    {
        var result = await _userRoleService.GetAllUserRole();
        return Ok(result);
    }

    [HttpGet("GetUserRoleByUserId")]
    public async Task<IActionResult> GetUserRoleByUserId(Guid id)
    {
        var result = await _userRoleService.GetRolesbyUserId(id);
        return Ok(result);
    }

    [HttpPut("UpdateUserRole")]
    public async Task<IActionResult> UpdateUserRole(UserRoleViewModel userRoleViewModel)
    {
        var result = await _userRoleService.UpdateUserRole(userRoleViewModel);

        if (result == ResultUserRole.duplicate) return BadRequest("UserRole Is Duplicate");

        if (result == ResultUserRole.notFound) return BadRequest("UserRole Is No Found");

        if (result == ResultUserRole.Error) return BadRequest("Error In Update UserRole");

        return Ok("Success");
    }
}
