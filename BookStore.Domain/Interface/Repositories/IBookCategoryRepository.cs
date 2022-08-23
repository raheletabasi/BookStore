using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IBookCategoryRepository : IGenericRepository<BookCategory>
{
    public Task IsDuplicate(Guid bookId, Guid catrgoryId);
    public Task IsDuplicate(Guid id, Guid bookId, Guid catrgoryId);
}
