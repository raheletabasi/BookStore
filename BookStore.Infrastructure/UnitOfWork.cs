using BookStore.Domain.Interface;
using BookStore.Domain.Interface.Repositories;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly BookStoreContext _context;

    public UnitOfWork(BookStoreContext context)
    {
        _context = context;
    }

    public IAuthorRepository Authors { get; }

    public IBookCategoryRepository BookCategories { get; }

    public IBookRepository Books { get; }

    public ICategoryRepository Categories { get; }
    public IPublisherRepository Publishers { get; }

    public IOrderDetailRepository OrderDetails { get; }

    public IOrderRepository Orders { get; }

    public IPermissionRepository Permissions { get; }

    public IRolePermissionRepository RolePermission { get; }

    public IRoleRepository Roles { get; }

    public IUserRoleRepository UserRoles { get; }

    public IUserRepository Users { get; }

    public async Task<bool> Commit()
    {
        var success = (await _context.SaveChangesAsync()) > 0;
        return success;
    }

    public void Dispose() => _context.Dispose();

    public Task Rollback()
    {
        return Task.CompletedTask;
    }
}
