using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<ResultCategory> AddCategory(CategoryViewModel categoryViewModel)
    {
        try
        {
            var isDuplicate = await _categoryRepository.IsDuplicate(categoryViewModel.Title);

            if (!isDuplicate)
            {
                var category = new Category()
                {
                    Title = categoryViewModel.Title
                };

                await _categoryRepository.AddAsync(category);
                await _categoryRepository.Save();

                return ResultCategory.success;
            }
            return ResultCategory.duplicate;
        }
        catch
        {
            return ResultCategory.Error;
        }
    }

    public async Task<ResultCategory> DeleteCategory(Guid id)
    {
        try
        {
            var isExist = await _categoryRepository.IsExist(id);
            if (isExist)
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                await _categoryRepository.DeleteAsync(category);
                await _categoryRepository.Save();

                return ResultCategory.success;
            }
            return ResultCategory.notFound;
        }
        catch
        {
            return ResultCategory.Error;
        }
    }

    public List<Category> GetAllCategory()
    {
        return _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryById(Guid id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task<ResultCategory> UpdateCategory(CategoryViewModel CategoryviewModel)
    {
        try
        {
            var isExist = await _categoryRepository.IsExist(CategoryviewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _categoryRepository.IsDuplicate(
                    CategoryviewModel.Id, CategoryviewModel.Title);

                if (!isDuplicate)
                {
                    var category = new Category()
                    {
                        Title = CategoryviewModel.Title
                    };

                    await _categoryRepository.UpdateAsync(category);
                    await _categoryRepository.Save();

                    return ResultCategory.success;
                }
                return ResultCategory.duplicate;
            }
            return ResultCategory.notFound;
        }
        catch
        {
            return ResultCategory.Error;
        }
    }
}
