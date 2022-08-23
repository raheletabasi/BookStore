using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task IsDuplicate(string name, string family, string email);
    public Task IsDuplicate(Guid id,string name, string family, string email);
}
