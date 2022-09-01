using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;

    public UserRoleService(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    public async Task<ResultUserRole> AddUserRole(UserRoleViewModel userRoleViewModel)
    {
        try
        {
            var isDuplicate = await _userRoleRepository.IsDuplicate(userRoleViewModel.UserId, userRoleViewModel.RoleId);

            if (!isDuplicate)
            {
                var userRole = new UserRole()
                {
                    UserId = userRoleViewModel.UserId,
                    RoleId = userRoleViewModel.RoleId
                };

                await _userRoleRepository.AddAsync(userRole);
                await _userRoleRepository.Save();

                return ResultUserRole.success;
            }
            return ResultUserRole.duplicate;
        }
        catch
        {
            return ResultUserRole.Error;
        }
    }

    public async Task<ResultUserRole> DeleteUserRole(Guid id)
    {
        try
        {
            var isExist = await _userRoleRepository.IsExist(id);
            if (isExist)
            {
                var userRole = await _userRoleRepository.GetByIdAsync(id);
                await _userRoleRepository.DeleteAsync(userRole);
                await _userRoleRepository.Save();

                return ResultUserRole.success;
            }
            return ResultUserRole.notFound;
        }
        catch
        {
            return ResultUserRole.Error;
        }
    }

    public List<UserRole> GetAllUserRole()
    {
        return _userRoleRepository.GetAllAsync();
    }

    public async Task<UserRole> GetRolesbyUserId(Guid userId)
    {
        return await _userRoleRepository.GetByIdAsync(userId);
    }

    public async Task<ResultUserRole> UpdateUserRole(UserRoleViewModel userRoleViewModel)
    {
        try
        {
            var isExist = await _userRoleRepository.IsExist(userRoleViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _userRoleRepository.IsDuplicate(
                    userRoleViewModel.Id, userRoleViewModel.UserId, userRoleViewModel.RoleId);

                if (!isDuplicate)
                {
                    var userRole = new UserRole()
                    {
                        UserId = userRoleViewModel.UserId,
                        RoleId = userRoleViewModel.RoleId
                    };

                    await _userRoleRepository.UpdateAsync(userRole);
                    await _userRoleRepository.Save();

                    return ResultUserRole.success;
                }
                return ResultUserRole.duplicate;
            }
            return ResultUserRole.notFound;
        }
        catch
        {
            return ResultUserRole.Error;
        }
    }
}
