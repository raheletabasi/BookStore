using BookStore.Application.Interfaces;
using BookStore.Application.Services;
using BookStore.Domain.Interface.Repositories;
using BookStore.Domain.Repositories;
using BookStore.Domain.Repositories.Generic;
using BookStore.Infrastructure.GenericRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application.IoC;

public class DependencyContainer
{
    public static void RegisterService(IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        #region Service
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookCategoryService, BookCategoryService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderDetailService, OrderDetailService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IPublisherService, PublisherService>();
        //services.AddScoped<IRoleService, RoleService>();
        #endregion

    }
}
