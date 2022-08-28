using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;

namespace BookStore.Application.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserRoleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultUserRole> AddUserRole(UserRoleViewModel userRoleViewModel)
    {
        try
        {
            var isDuplicate = await _unitOfWork.UserRoles.IsDuplicate(userRoleViewModel.UserId, userRoleViewModel.RoleId);

            if (!isDuplicate)
            {
                var userRole = new UserRole()
                {
                    UserId = userRoleViewModel.UserId,
                    RoleId = userRoleViewModel.RoleId
                };

                await _unitOfWork.UserRoles.AddAsync(userRole);
                await _unitOfWork.Commit();

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
            var isExist = await _unitOfWork.UserRoles.IsExist(id);
            if (isExist)
            {
                var userRole = await _unitOfWork.UserRoles.GetByIdAsync(id);
                await _unitOfWork.UserRoles.DeleteAsync(userRole);
                await _unitOfWork.Commit();

                return ResultUserRole.success;
            }
            return ResultUserRole.notFound;
        }
        catch
        {
            return ResultUserRole.Error;
        }
    }

    public async Task<IEnumerable<UserRole>> GetAllUserRole()
    {
        return await _unitOfWork.UserRoles.GetAllAsync();
    }

    public async Task<UserRole> GetRolesbyUserId(Guid userId)
    {
        return await _unitOfWork.UserRoles.GetByIdAsync(userId);
    }

    public async Task<ResultUserRole> UpdateUserRole(UserRoleViewModel userRoleViewModel)
    {
        try
        {
            var isExist = await _unitOfWork.UserRoles.IsExist(userRoleViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _unitOfWork.UserRoles.IsDuplicate(
                    userRoleViewModel.Id, userRoleViewModel.UserId, userRoleViewModel.RoleId);

                if (!isDuplicate)
                {
                    var userRole = new UserRole()
                    {
                        UserId = userRoleViewModel.UserId,
                        RoleId = userRoleViewModel.RoleId
                    };

                    await _unitOfWork.UserRoles.UpdateAsync(userRole);
                    await _unitOfWork.Commit();

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
