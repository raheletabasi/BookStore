using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IRoleRepository : IGenericRepository<Role>
{
    public Task IsDuplicate(string title);
    public Task IsDuplicate(Guid id, string title);
}
