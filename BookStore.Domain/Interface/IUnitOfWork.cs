﻿using BookStore.Domain.Repositories;

namespace BookStore.Domain.Interface;

public interface IUnitOfWork : IDisposable
{
    IBookCategoryRepository BookCategories { get; }
    IBookRepository Books { get; }
    ICategoryRepository Categories { get; }
    IOrderDetailRepository OrderDetails { get; }
    IOrderRepository Orders { get; }
    IPermissionRepository Permissions { get; }
    IRolePermissionRepository RolePermission { get; }
    IRoleRepository Roles { get; }
    IUserRoleRepository UserRoles { get; }
    IUserRepository Users { get; }

    Task<bool> Commit();
    Task Rollback();
}