using BookStore.Application.DTOs.User;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUserViewModel register)
    {
        var result = await _userService.RegisterUser(register);
   
        if (result == ResultRegisterUser.Duplicate) return BadRequest("Email and/or UserName Is Duplicate");
        if (result == ResultRegisterUser.Error) return BadRequest("Error In Register User");

        return Ok("Success");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserViewModel login)
    {
        var result = await _userService.LoginUser(login);

        if (result == ResultLoginUser.Error) return BadRequest("Error In Login User");
        if (result == ResultLoginUser.notFound) return BadRequest("User Not Found");
        if (result == ResultLoginUser.block) return BadRequest("User Is Block");
        if (result == ResultLoginUser.inactive) return BadRequest("User Is Inactive");

        return Ok("Success");
    }

    [HttpPut("EditProfile")]
    public async Task<IActionResult> EditProfile(Guid userId, EditUserProfileViewModel editUserProfile)
    {
        var result = await _userService.EditProfile(userId, editUserProfile);

        if (result == ResultEditUserProfile.notFound) return BadRequest("User Not Found");
        if (result == ResultEditUserProfile.error) return BadRequest("Error In Edit Profile");

        return Ok("Success");
    }

    [HttpPut("ChangePassword")]
    public async Task<IActionResult> ChangePassword(Guid userId, ChangePasswordViewModel changePassword)
    {
        var result = await _userService.ChangePassword(userId, changePassword);

        if (result == ResultChangePassword.error) return BadRequest("Error In Change Password");
        if (result == ResultChangePassword.notFound) return BadRequest("User Not Found");
        if (result == ResultChangePassword.equalPassword) return BadRequest("New Password Is Equal to Current Password");

        return Ok("Success");
    }

    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _userService.GetAllUser();
        return Ok(result);
    }

    [HttpGet("GetByUserId")]
    public async Task<IActionResult> GetById(Guid userId)
    {
        var result = await _userService.GetUserByUserId(userId);
        return Ok(result);
    }

}
