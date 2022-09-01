using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services;

public class RolePermissionService : IRolePermissionService
{
    private readonly IRolePermissionRepository _rolePermissionRepository;

    public RolePermissionService(IRolePermissionRepository rolePermissionRepository)
    {
        _rolePermissionRepository = rolePermissionRepository;
    }

    public async Task<ResultRolePermission> AddRolePermission(RolePermissionViewModel rolePermissionViewModel)
    {
        try
        {
            var isDuplicate = await _rolePermissionRepository.IsDuplicate(rolePermissionViewModel.RoleId, rolePermissionViewModel.PermissionId);

            if (!isDuplicate)
            {
                var rolePermission = new RolePermission()
                {
                    RoleId = rolePermissionViewModel.RoleId,
                    PermissionId = rolePermissionViewModel.PermissionId
                };

                await _rolePermissionRepository.AddAsync(rolePermission);
                await _rolePermissionRepository.Save();

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
            var isExist = await _rolePermissionRepository.IsExist(id);
            if (isExist)
            {
                var rolePermissionCategory = await _rolePermissionRepository.GetByIdAsync(id);
                await _rolePermissionRepository.DeleteAsync(rolePermissionCategory);
                await _rolePermissionRepository.Save();

                return ResultRolePermission.success;
            }
            return ResultRolePermission.notFound;
        }
        catch
        {
            return ResultRolePermission.Error;
        }
    }

    public List<RolePermission> GetAllRolePermission()
    {
        return _rolePermissionRepository.GetAllAsync();
    }

    public async Task<RolePermission> GetRolePermissionbyRoleId(Guid roleId)
    {
        return await _rolePermissionRepository.GetByIdAsync(roleId);
    }

    public async Task<ResultRolePermission> UpdateRolePermission(RolePermissionViewModel rolePermissionViewModel)
    {
        try
        {
            var isExist = await _rolePermissionRepository.IsExist(rolePermissionViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _rolePermissionRepository.IsDuplicate(
                    rolePermissionViewModel.Id, rolePermissionViewModel.RoleId, rolePermissionViewModel.PermissionId);

                if (!isDuplicate)
                {
                    var rolePermission = new RolePermission()
                    {
                        RoleId = rolePermissionViewModel.RoleId,
                        PermissionId = rolePermissionViewModel.PermissionId
                    };

                    await _rolePermissionRepository.UpdateAsync(rolePermission);
                    await _rolePermissionRepository.Save();

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
