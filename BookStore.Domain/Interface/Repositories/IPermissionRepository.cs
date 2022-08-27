using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IPermissionRepository : IGenericRepository<Permission>
{
    public Task<bool> IsDuplicate(string title, Guid? permissionId);
    public Task<bool> IsDuplicate(Guid id, string title, Guid? permissionId);
    Task<IEnumerable<Permission>> GetAllChildByPermissionId(Guid permissionId);
}
