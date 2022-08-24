using BookStore.Application.DTOs;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface IUserService
{
    Task<User> GetUserByUserId(Guid userId);
    Task<IEnumerable<User>> GetAllUser();
    Task<ResultRegisterUser> RegisterUser(RegisterUserViewModel registerViewModel);
    Task<ResultLoginUser> LoginUser(LoginUserViewModel loginUserViewModel);
    Task<ResultEditUserProfile> EditProfile(Guid userId, EditUserProfileViewModel editUserProfileViewModel);
    Task<ResultChangePassword> ChangePassword(Guid userId, ChangePasswordViewModel changePasswordViewModel);

}
