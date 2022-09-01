using BookStore.Application.DTOs.User;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface IUserService
{
    Task<User> GetUserByUserId(Guid userId);
    List<User> GetAllUser();
    Task<ResultRegisterUser> RegisterUser(RegisterUserViewModel registerViewModel);
    Task<ResultLoginUser> LoginUser(LoginUserViewModel loginUserViewModel);
    Task<ResultEditUserProfile> EditProfile(Guid userId, EditUserProfileViewModel editUserProfileViewModel);
    Task<ResultChangePassword> ChangePassword(Guid userId, ChangePasswordViewModel changePasswordViewModel);
    //Task<UserFilterViewModel> FilterUsers(UserFilterViewModel filter);
}
