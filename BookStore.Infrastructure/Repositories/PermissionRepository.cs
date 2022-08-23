using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
{
    public PermissionRepository(BookStoreContext context) : base(context)
    {
    }
}
