using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    private readonly BookStoreContext _context;

    public AuthorRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public Task<bool> IsDuplicate(string name, string family)
    {
        return Task.FromResult(_context.Author.Any(x => x.FirstName.Equals(name) && x.LastName.Equals(family)));
    }

    public Task<bool> IsDuplicate(Guid id, string name, string family)
    {
        return Task.FromResult(_context.Author.Any(x =>
        !x.Id.Equals(id) &&
        x.FirstName.Equals(name) && 
        x.LastName.Equals(family)));
    }
}
