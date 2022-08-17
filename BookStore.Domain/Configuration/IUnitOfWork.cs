using BookStore.Domain.BookCategories;
using BookStore.Domain.Books;
using BookStore.Domain.Categories;
using BookStore.Domain.OrderDetails;
using BookStore.Domain.Orders;
using BookStore.Domain.Permissions;
using BookStore.Domain.RolePermissions;
using BookStore.Domain.Roles;
using BookStore.Domain.UserRoles;
using BookStore.Domain.Users;

namespace BookStore.Domain.Configuration;

public interface IUnitOfWork
{
    IBookCategoryRepository bookCategories { get; }
    IBookRepository books { get; }
    ICategoryRepository categories { get; }
    IOrderDetailRepository orderDetails { get; }
    IOrderRepository orders { get; }
    IPermissionRepository permissions { get; }
    IRolePermissionRepository rolePermission { get; }
    IRoleRepository roles { get; }
    IUserRoleRepository userRoles { get; }
    IUserRepository users { get; }
}
