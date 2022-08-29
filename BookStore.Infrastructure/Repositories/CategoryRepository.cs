using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly BookStoreContext _context;

    public CategoryRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsDuplicate(string title)
    {
        return await Task.FromResult(_context.Category.Any(x => x.Title.Equals(title)));
    }

    public async Task<bool> IsDuplicate(Guid id, string title)
    {
        return await Task.FromResult(_context.Category.Any(x => 
            x.Id.Equals(id) &&
            x.Title.Equals(title)));
    }
}
