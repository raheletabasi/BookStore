using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IPermissionRepository : IGenericRepository<Permission>
{
    public Task IsDuplicate(string title, long parent);
    public Task IsDuplicate(Guid id, string title, long parent));
}
