using BookStore.Application.DTOs;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface ICategoryService
{
    Task<ResultCategory> AddCategory(CategoryViewModel categoryViewModel);
    Task<ResultCategory> UpdateCategory(CategoryViewModel CategoryviewModel);
    Task<ResultCategory> DeleteCategory(Guid id);
    Task<Category> GetCategoryById(Guid id);
    Task<IEnumerable<Category>> GetAllCategory();
}
