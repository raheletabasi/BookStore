using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
{
    private readonly BookStoreContext _context;

    public PermissionRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Permission>> GetAllChildByPermissionId(Guid permissionId)
    {
        return await Task.FromResult(_context.Permission.Where(x => x.PermissionId.Equals(permissionId)));
    }

    public async Task<bool> IsDuplicate(string title, Guid? permissionId = null)
    {
        return await Task.FromResult(_context.Permission.Any(x => x.Title.Equals(title) && x.PermissionId == permissionId));
    }

    public async Task<bool> IsDuplicate(Guid id, string title, Guid? permissionId = null)
    {
        return await Task.FromResult(_context.Permission.Any(x => 
        !x.Id.Equals(id) &&
        x.Title.Equals(title) && 
        x.PermissionId == permissionId));
    }
}
