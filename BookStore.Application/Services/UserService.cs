using BookStore.Application.DTOs.Common;
using BookStore.Application.DTOs.User;
using BookStore.Application.Interfaces;
using BookStore.Application.Security;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultChangePassword> ChangePassword(Guid userId, ChangePasswordViewModel changePasswordViewModel)
    {
        try
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                var newPass = PasswordHelper.EncodePasswordMd5(changePasswordViewModel.NewPassword);
                if (user.Password != newPass)
                {
                    user.Password = newPass;
                    await _userRepository.UpdateAsync(user);
                    await _userRepository.Save();

                    return ResultChangePassword.success;
                }
                return ResultChangePassword.equalPassword;
            }
            return ResultChangePassword.notFound;
        }
        catch
        {
            return ResultChangePassword.error;
        }
    }

    public async Task<ResultEditUserProfile> EditProfile(Guid userId,EditUserProfileViewModel editUserProfileViewModel)
    {
        try
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return ResultEditUserProfile.notFound;

            user.FirstName = editUserProfileViewModel.FirstName;
            user.LastName = editUserProfileViewModel.LastName;
            user.Mobile = editUserProfileViewModel.Mobile;
            user.Gender = editUserProfileViewModel.Gender;
            user.Birthdate = editUserProfileViewModel.Birthdate;
            user.State = editUserProfileViewModel.State;
            user.City = editUserProfileViewModel.City;
            user.Address = editUserProfileViewModel.Address;
            user.PostalCode = editUserProfileViewModel.PostalCode;

            await _userRepository.UpdateAsync(user);
            await _userRepository.Save();

            return ResultEditUserProfile.success;
        }
        catch
        {
            return ResultEditUserProfile.error;
        }
    }

    //public async Task<UserFilterViewModel> FilterUsers(UserFilterViewModel filter)
    //{
        //var query = _userRepository.GetAllAsync();

        //if (!string.IsNullOrEmpty(filter.UserName))
        //{
        //    query = query.Where(c => c.UserName == filter.UserName);
        //}

        //#region paging
        //var pager = Pager.Build(filter.PageId, query.Count(), filter.TakeEntity, filter.CountForShowAfterAndBefor);
        //var allData = query.Paging(pager).ToList();
        //#endregion

        //return filter.SetPaging(pager).SetUsers(allData);
    //}

    public List<User> GetAllUser()
    {
        return _userRepository.GetAllAsync();
    }

    public async Task<User> GetUserByUserId(Guid userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public async Task<ResultLoginUser> LoginUser(LoginUserViewModel loginUserViewModel)
    {
        try
        {
            var user = await _userRepository.GetUserByEmail(loginUserViewModel.Email);
            if (user == null) return ResultLoginUser.notFound;
            if (user.Status == UserStatus.Inactive) return ResultLoginUser.inactive;
            if (user.Status == UserStatus.Block) return ResultLoginUser.block;

            return ResultLoginUser.success;
        }
        catch
        {
            return ResultLoginUser.Error;
        }
    }

    public async Task<ResultRegisterUser> RegisterUser(RegisterUserViewModel registerViewModel)
    {
        try
        {
            var isDuplicateUser = await _userRepository.IsDuplicate(registerViewModel.UserName, registerViewModel.Email);
            if (!isDuplicateUser)
            {
                var newUser = new User
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.UserName,
                    Mobile = registerViewModel.Mobile,
                    Password = PasswordHelper.EncodePasswordMd5(registerViewModel.Password)
                };

                await _userRepository.AddAsync(newUser);
                await _userRepository.Save();

                return ResultRegisterUser.success;
            }
            return ResultRegisterUser.Duplicate;
        }
        catch
        {
            return ResultRegisterUser.Error;
        }


    }
}
