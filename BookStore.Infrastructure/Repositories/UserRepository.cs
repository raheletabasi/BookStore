using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly BookStoreContext _context;

    public UserRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _context.User.FirstOrDefaultAsync(x => x.Equals(email));
    }

    public async Task<User> GetUserByMobile(string mobile)
    {
        return await _context.User.FirstOrDefaultAsync(x => x.Equals(mobile));
    }

    public async Task<User> GetUserByUserName(string userName)
    {
        return await _context.User.FirstOrDefaultAsync(x => x.Equals(userName));
    }

    public async Task<bool> IsDuplicate(string userName, string email)
    {
        return await _context.User.AnyAsync(x => x.UserName.Equals(userName) && x.Email.Equals(email));
    }

    public async Task<bool> IsDuplicate(Guid id, string userName, string email)
    {
        return await _context.User.AnyAsync(x => !x.Id.Equals(id) && x.UserName.Equals(userName) && x.Email.Equals(email));
    }
}
