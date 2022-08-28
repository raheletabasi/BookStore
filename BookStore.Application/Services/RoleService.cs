using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;

namespace BookStore.Application.Services;

public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultRole> AddRole(RoleViewModel roleViewModel)
    {
        try
        {
            var isDuplicate = await _unitOfWork.Roles.IsDuplicate(roleViewModel.Title);

            if (!isDuplicate)
            {
                var role = new Role()
                {
                    Title = roleViewModel.Title
                };

                await _unitOfWork.Roles.AddAsync(role);
                await _unitOfWork.Commit();

                return ResultRole.success;
            }
            return ResultRole.duplicate;
        }
        catch
        {
            return ResultRole.Error;
        }
    }

    public async Task<ResultRole> DeleteRole(Guid id)
    {
        try
        {
            var isExist = await _unitOfWork.Roles.IsExist(id);
            if (isExist)
            {
                var role = await _unitOfWork.Roles.GetByIdAsync(id);
                await _unitOfWork.Roles.DeleteAsync(role);
                await _unitOfWork.Commit();

                return ResultRole.success;
            }
            return ResultRole.notFound;
        }
        catch
        {
            return ResultRole.Error;
        }
    }

    public async Task<IEnumerable<Role>> GetAllRoles()
    {
        return await _unitOfWork.Roles.GetAllAsync();
    }

    public async Task<Role> GetRolebyId(Guid roleId)
    {
        return await _unitOfWork.Roles.GetByIdAsync(roleId);
    }

    public async Task<ResultRole> UpdateRole(RoleViewModel roleViewModel)
    {
        try
        {
            var isExist = await _unitOfWork.Roles.IsExist(roleViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _unitOfWork.Roles.IsDuplicate(
                    roleViewModel.Id, roleViewModel.Title);

                if (!isDuplicate)
                {
                    var role = new Role()
                    {
                        Title = roleViewModel.Title
                    };

                    await _unitOfWork.Roles.UpdateAsync(role);
                    await _unitOfWork.Commit();

                    return ResultRole.success;
                }
                return ResultRole.duplicate;
            }
            return ResultRole.notFound;
        }
        catch
        {
            return ResultRole.Error;
        }
    }
}
