using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
{
    private readonly BookStoreContext _context;
    public UserRoleRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsDuplicate(Guid userId, Guid roleId)
    {
        return await Task.FromResult(_context.UserRole.Any(x => x.UserId.Equals(userId) &&          x.RoleId.Equals(roleId)));
    }

    public async Task<bool> IsDuplicate(Guid id, Guid userId, Guid roleId)
    {
        return await Task.FromResult(_context.UserRole.Any(x => 
            !x.Id.Equals(id) &&
            x.UserId.Equals(userId) && 
            x.RoleId.Equals(roleId)));
    }
}
