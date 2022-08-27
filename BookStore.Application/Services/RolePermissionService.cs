using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;

namespace BookStore.Application.Services;

public class RolePermissionService : IRolePermissionService
{
    private readonly IUnitOfWork _unitOfWork;

    public RolePermissionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultRolePermission> AddRolePermission(RolePermissionViewModel rolePermissionViewModel)
    {
        try
        {
            var isDuplicate = await _unitOfWork.RolePermission.IsDuplicate(rolePermissionViewModel.RoleId, rolePermissionViewModel.PermissionId);

            if (!isDuplicate)
            {
                var rolePermission = new RolePermission()
                {
                    RoleId = rolePermissionViewModel.RoleId,
                    PermissionId = rolePermissionViewModel.PermissionId
                };

                await _unitOfWork.RolePermission.AddAsync(rolePermission);
                await _unitOfWork.Commit();

                return ResultRolePermission.success;
            }
            return ResultRolePermission.duplicate;
        }
        catch
        {
            return ResultRolePermission.Error;
        }
    }

    public async Task<ResultRolePermission> DeleteRolePermission(Guid id)
    {
        try
        {
            var isExist = await _unitOfWork.RolePermission.IsExist(id);
            if (isExist)
            {
                var rolePermissionCategory = await _unitOfWork.RolePermission.GetByIdAsync(id);
                await _unitOfWork.RolePermission.DeleteAsync(rolePermissionCategory);
                await _unitOfWork.Commit();

                return ResultRolePermission.success;
            }
            return ResultRolePermission.notFound;
        }
        catch
        {
            return ResultRolePermission.Error;
        }
    }

    public async Task<IEnumerable<RolePermission>> GetAllRolePermission()
    {
        return await _unitOfWork.RolePermission.GetAllAsync();
    }

    public async Task<RolePermission> GetRolePermissionbyRoleId(Guid roleId)
    {
        return await _unitOfWork.RolePermission.GetByIdAsync(roleId);
    }

    public async Task<ResultRolePermission> UpdateRolePermission(RolePermissionViewModel rolePermissionViewModel)
    {
        try
        {
            var isExist = await _unitOfWork.RolePermission.IsExist(rolePermissionViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _unitOfWork.RolePermission.IsDuplicate(
                    rolePermissionViewModel.Id, rolePermissionViewModel.RoleId, rolePermissionViewModel.PermissionId);

                if (!isDuplicate)
                {
                    var rolePermission = new RolePermission()
                    {
                        RoleId = rolePermissionViewModel.RoleId,
                        PermissionId = rolePermissionViewModel.PermissionId
                    };

                    await _unitOfWork.RolePermission.UpdateAsync(rolePermission);
                    await _unitOfWork.Commit();

                    return ResultRolePermission.success;
                }
                return ResultRolePermission.duplicate;
            }
            return ResultRolePermission.notFound;
        }
        catch
        {
            return ResultRolePermission.Error;
        }
    }
}
