using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IRolePermissionRepository : IGenericRepository<RolePermission>
{
    public Task IsDuplicate(Guid roleId, Guid permissionId);
    public Task IsDuplicate(Guid id, Guid roleId, Guid permissionId);
}
