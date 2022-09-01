using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;

    public PermissionService(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<ResultPermission> AddPermission(PermissionViewModel permissionViewModel)
    {
        try
        {
            var isDuplicate = await _permissionRepository.IsDuplicate(permissionViewModel.Title, permissionViewModel.PermissionId);

            if (!isDuplicate)
            {
                var permission = new Permission()
                {
                    Title = permissionViewModel.Title,
                    PermissionId = permissionViewModel.PermissionId
                };

                await _permissionRepository.AddAsync(permission);
                await _permissionRepository.Save();

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
            var isExist = await _permissionRepository.IsExist(id);
            if (isExist)
            {
                var permission = await _permissionRepository.GetByIdAsync(id);
                await _permissionRepository.DeleteAsync(permission);
                await _permissionRepository.Save();

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
        return await _permissionRepository.GetAllChildByPermissionId(permissionId);
    }

    public List<Permission> GetAllPermission()
    {
        return _permissionRepository.GetAllAsync();
    }

    public async Task<Permission> GetPermissionById(Guid id)
    {
        return await _permissionRepository.GetByIdAsync(id);
    }

    public async Task<ResultPermission> UpdatePermission(PermissionViewModel permissionViewModel)
    {
        try
        {
            var isExist = await _permissionRepository.IsExist(permissionViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _permissionRepository.IsDuplicate(
                    permissionViewModel.Id, permissionViewModel.Title, permissionViewModel.PermissionId);

                if (!isDuplicate)
                {
                    var permission = new Permission()
                    {
                        Title = permissionViewModel.Title
                    };

                    await _permissionRepository.UpdateAsync(permission);
                    await _permissionRepository.Save();

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
