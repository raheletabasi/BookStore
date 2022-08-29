using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IBookRepository : IGenericRepository<Book>
{
    public Task<bool> IsDuplicate(string title, Guid autherId, Guid publisherId);
    public Task<bool> IsDuplicate(Guid id, string title, Guid authorId, Guid publisherId);
}
