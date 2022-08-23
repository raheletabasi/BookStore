using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class BookCategoryRepository : GenericRepository<BookCategory>, IBookCategoryRepository
{
    public BookCategoryRepository(BookStoreContext context) : base(context)
    {
    }
}
