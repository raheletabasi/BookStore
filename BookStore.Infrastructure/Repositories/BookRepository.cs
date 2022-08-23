using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(BookStoreContext context) : base(context)
    {
    }

    public Task IsDuplicate(string name)
    {
        throw new NotImplementedException();
    }

    public Task IsDuplicate(Guid Id, string name)
    {
        throw new NotImplementedException();
    }
}
