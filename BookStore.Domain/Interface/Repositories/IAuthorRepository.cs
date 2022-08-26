using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task<bool> IsDuplicate(string name, string family);
    public Task<bool> IsDuplicate(Guid id,string name, string family);
}
