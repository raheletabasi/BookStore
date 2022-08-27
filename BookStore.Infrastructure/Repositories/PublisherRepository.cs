using BookStore.Domain.Interface.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

public class PublisherRepository : GenericRepository<Domain.Entities.Publisher>, IPublisherRepository
{
    private readonly BookStoreContext _context;

    public PublisherRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsDuplicate(string title)
    {
        return await Task.FromResult(_context.Publisher.Any(x => x.Title.Equals(title)));
    }

    public async Task<bool> IsDuplicate(Guid id, string title)
    {
        return await Task.FromResult(_context.Publisher.Any(x => 
        !x.Id.Equals(id) &&
        x.Title.Equals(title)));
    }
}
