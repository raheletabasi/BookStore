using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IRoleRepository : IGenericRepository<Role>
{
    public Task<bool> IsDuplicate(string title);
    public Task<bool> IsDuplicate(Guid id, string title);
}
