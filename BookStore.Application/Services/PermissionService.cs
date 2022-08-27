using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;

namespace BookStore.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IUnitOfWork _unitOfWork;

    public PermissionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultPermission> AddPermission(PermissionViewModel permissionViewModel)
    {
        try
        {
            var isDuplicate = await _unitOfWork.Permissions.IsDuplicate(permissionViewModel.Title, permissionViewModel.PermissionId);

            if (!isDuplicate)
            {
                var permission = new Permission()
                {
                    Title = permissionViewModel.Title,
                    PermissionId = permissionViewModel.PermissionId
                };

                await _unitOfWork.Permissions.AddAsync(permission);
                await _unitOfWork.Commit();

                return ResultPermission.success;
            }
            return ResultPermission.duplicate;
        }
        catch
        {
            return ResultPermission.Error;
        }
    }

    public async Task<ResultPermission> DeletePermission(Guid id)
    {
        try
        {
            var isExist = await _unitOfWork.Permissions.IsExist(id);
            if (isExist)
            {
                var permission = await _unitOfWork.Permissions.GetByIdAsync(id);
                await _unitOfWork.Permissions.DeleteAsync(permission);
                await _unitOfWork.Commit();

                return ResultPermission.success;
            }
            return ResultPermission.notFound;
        }
        catch
        {
            return ResultPermission.Error;
        }
    }

    public async Task<IEnumerable<Permission>> GetAllChildByPermissionId(Guid permissionId)
    {
        return await _unitOfWork.Permissions.GetAllChildByPermissionId(permissionId);
    }

    public async Task<IEnumerable<Permission>> GetAllPermission()
    {
        return await _unitOfWork.Permissions.GetAllAsync();
    }

    public async Task<Permission> GetPermissionById(Guid id)
    {
        return await _unitOfWork.Permissions.GetByIdAsync(id);
    }

    public async Task<ResultPermission> UpdatePermission(PermissionViewModel permissionViewModel)
    {
        try
        {
            var isExist = await _unitOfWork.Permissions.IsExist(permissionViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _unitOfWork.Permissions.IsDuplicate(
                    permissionViewModel.Id, permissionViewModel.Title, permissionViewModel.PermissionId);

                if (!isDuplicate)
                {
                    var permission = new Permission()
                    {
                        Title = permissionViewModel.Title
                    };

                    await _unitOfWork.Permissions.UpdateAsync(permission);
                    await _unitOfWork.Commit();

                    return ResultPermission.success;
                }
                return ResultPermission.duplicate;
            }
            return ResultPermission.notFound;
        }
        catch
        {
            return ResultPermission.Error;
        }
    }
}
