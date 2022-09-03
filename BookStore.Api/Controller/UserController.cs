using BookStore.Application.DTOs.User;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public readonly IConfiguration _configuration;

    public UserController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUserViewModel register)
    {
        var result = await _userService.RegisterUser(register);
   
        if (result == ResultRegisterUser.Duplicate) return BadRequest("Email and/or UserName Is Duplicate");
        if (result == ResultRegisterUser.Error) return BadRequest("Error In Register User");

        return Ok("Success");
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserViewModel login)
    {
        var result = await _userService.LoginUser(login);

        if (result == ResultLoginUser.Error) return BadRequest("Error In Login User");
        if (result == ResultLoginUser.notFound) return BadRequest("User Not Found");
        if (result == ResultLoginUser.block) return BadRequest("User Is Block");
        if (result == ResultLoginUser.inactive) return BadRequest("User Is Inactive");

        var user = await _userService.GetUserByUserId(login.Id);
        return Ok(GenerateJwtToken(user));
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
        var result = _userService.GetAllUser();
        return Ok(result);
    }

    [HttpGet("GetByUserId")]
    public async Task<IActionResult> GetById(Guid userId)
    {
        var result = await _userService.GetUserByUserId(userId);
        return Ok(result);
    }

    #region JWT
    private string GenerateJwtToken(User user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtConfig:Secret"]));
        var claims = new[]
        { 
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWTServiceAccessToken"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("UserId", user.Id.ToString()),
            new Claim("UserName", user.UserName),
            new Claim("Email", user.Email)
        };
        var signIn = new SigningCredentials(key, SecurityAlgorithms.Aes128CbcHmacSha256);
        var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    #endregion

}
