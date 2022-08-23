using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(BookStoreContext context) : base(context)
    {
    }
}
