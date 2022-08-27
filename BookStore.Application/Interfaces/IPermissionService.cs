using BookStore.Application.DTOs;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface IPermissionService
{
    Task<ResultPermission> AddPermission(PermissionViewModel permissionViewModel);
    Task<ResultPermission> UpdatePermission(PermissionViewModel permissionViewModel);
    Task<ResultPermission> DeletePermission(Guid id);
    Task<IEnumerable<Permission>> GetAllPermission();
    Task<Permission> GetPermissionById(Guid id);
    Task<IEnumerable<Permission>> GetAllChildByPermissionId(Guid permissionId);
}
