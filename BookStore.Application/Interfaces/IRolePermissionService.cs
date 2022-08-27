using BookStore.Application.DTOs;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface IRolePermissionService
{
    Task<ResultRolePermission> AddRolePermission(RolePermissionViewModel rolePermissionViewModel);
    Task<ResultRolePermission> DeleteRolePermission(Guid id);
    Task<ResultRolePermission> UpdateRolePermission(RolePermissionViewModel rolePermissionViewModel);
    Task<IEnumerable<RolePermission>> GetAllRolePermission();
    Task<RolePermission> GetRolePermissionbyRoleId(Guid roleId);
}
