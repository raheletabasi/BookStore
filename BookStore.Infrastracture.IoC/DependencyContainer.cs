using BookStore.Application.Interfaces;
using BookStore.Application.Services;
using BookStore.Domain.Repositories;
using BookStore.Domain.Repositories.Generic;
using BookStore.Infrastructure.GenericRepository;
using BookStore.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure.IoC;

public class DependencyContainer
{
    public static void RegisterService(IServiceCollection services)
    {
        #region Repository
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IAuthorRepository,AuthorRepository>();
        services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        #endregion

        #region Service
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IBookCategoryService, BookCategoryService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderDetailService, OrderDetailService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IRolePermissionService, RolePermissionService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped <IUserService, UserService>();
        #endregion
    }
}
