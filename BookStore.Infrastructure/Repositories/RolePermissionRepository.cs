using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
{
    public RolePermissionRepository(BookStoreContext context) : base(context)
    {
    }
}
