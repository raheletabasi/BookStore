using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    public Task<bool> IsDuplicate(string title);
    public Task<bool> IsDuplicate(Guid id, string title);
}
