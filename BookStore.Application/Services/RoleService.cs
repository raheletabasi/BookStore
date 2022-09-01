using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ResultRole> AddRole(RoleViewModel roleViewModel)
    {
        try
        {
            var isDuplicate = await _roleRepository.IsDuplicate(roleViewModel.Title);

            if (!isDuplicate)
            {
                var role = new Role()
                {
                    Title = roleViewModel.Title
                };

                await _roleRepository.AddAsync(role);
                await _roleRepository.Save();

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
            var isExist = await _roleRepository.IsExist(id);
            if (isExist)
            {
                var role = await _roleRepository.GetByIdAsync(id);
                await _roleRepository.DeleteAsync(role);
                await _roleRepository.Save();

                return ResultRole.success;
            }
            return ResultRole.notFound;
        }
        catch
        {
            return ResultRole.Error;
        }
    }

    public List<Role> GetAllRoles()
    {
        return _roleRepository.GetAllAsync();
    }

    public async Task<Role> GetRolebyId(Guid roleId)
    {
        return await _roleRepository.GetByIdAsync(roleId);
    }

    public async Task<ResultRole> UpdateRole(RoleViewModel roleViewModel)
    {
        try
        {
            var isExist = await _roleRepository.IsExist(roleViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _roleRepository.IsDuplicate(
                    roleViewModel.Id, roleViewModel.Title);

                if (!isDuplicate)
                {
                    var role = new Role()
                    {
                        Title = roleViewModel.Title
                    };

                    await _roleRepository.UpdateAsync(role);
                    await _roleRepository.Save();

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
