using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    private readonly BookStoreContext _context;

    public BookRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsDuplicate(string title, Guid authorId, Guid publisherId)
    {
        return await Task.FromResult(_context.Book.Any(x => 
            x.Name.Equals(title) &&
            x.AuthorId.Equals(authorId) &&
            x.PublisherId.Equals(publisherId)));
    }

    public async Task<bool> IsDuplicate(Guid id, string title, Guid authorId, Guid publisherId)
    {
        return await Task.FromResult(_context.Book.Any(x =>
            !x.Id.Equals(id) &&
            x.Name.Equals(title) &&
            x.AuthorId.Equals(authorId) &&
            x.PublisherId.Equals(publisherId))); ;
    }
}
