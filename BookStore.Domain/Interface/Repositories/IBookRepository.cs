using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IBookRepository : IGenericRepository<Book>
{
    public Task IsDuplicate(string name);
    public Task IsDuplicate(Guid Id, string name);
}
