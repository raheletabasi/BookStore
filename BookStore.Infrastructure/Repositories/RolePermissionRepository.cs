using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
{
    private readonly BookStoreContext _context;

    public RolePermissionRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsDuplicate(Guid roleId, Guid permissionId)
    {
        return await Task.FromResult(_context.RolePermission.Any(x => x.RoleId.Equals(roleId) && x.PermissionId.Equals(permissionId)));
    }

    public async Task<bool> IsDuplicate(Guid id, Guid roleId, Guid permissionId)
    {
        return await Task.FromResult(_context.RolePermission.Any(x =>
            !x.Id.Equals(id) &&
            x.RoleId.Equals(roleId) &&
            x.Permission.Equals(permissionId)));
    }
}
