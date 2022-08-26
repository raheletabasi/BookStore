using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class BookCategoryRepository : GenericRepository<BookCategory>, IBookCategoryRepository
{
    private readonly BookStoreContext _context;

    public BookCategoryRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsDuplicate(Guid bookId, Guid categoryId)
    {
        return await Task.FromResult(_context.BookCategory.Any(x => x.BookId.Equals(bookId)
            && x.CategoryId.Equals(categoryId)))
    }

    public Task<bool> IsDuplicate(Guid id, Guid bookId, Guid catrgoryId)
    {
        throw new NotImplementedException();
    }
}
