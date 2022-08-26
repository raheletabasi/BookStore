using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;

namespace BookStore.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultCategory> AddCategory(CategoryViewModel categoryViewModel)
    {
        try
        {
            var isDuplicate = await _unitOfWork.Categories.IsDuplicate(categoryViewModel.Title);

            if (!isDuplicate)
            {
                var category = new Category()
                {
                    Title = categoryViewModel.Title
                };

                await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.Commit();

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
            var isExist = await _unitOfWork.Categories.IsExist(id);
            if (isExist)
            {
                var category = await _unitOfWork.Categories.GetByIdAsync(id);
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.Commit();

                return ResultCategory.success;
            }
            return ResultCategory.notFound;
        }
        catch
        {
            return ResultCategory.Error;
        }
    }

    public async Task<IEnumerable<Category>> GetAllCategory()
    {
        return await _unitOfWork.Categories.GetAllAsync();
    }

    public async Task<Category> GetCategoryById(Guid id)
    {
        return await _unitOfWork.Categories.GetByIdAsync(id);
    }

    public async Task<ResultCategory> UpdateCategory(CategoryViewModel CategoryviewModel)
    {
        try
        {
            var isExist = await _unitOfWork.Categories.IsExist(CategoryviewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _unitOfWork.Categories.IsDuplicate(
                    CategoryviewModel.Id, CategoryviewModel.Title);

                if (!isDuplicate)
                {
                    var category = new Category()
                    {
                        Title = CategoryviewModel.Title
                    };

                    await _unitOfWork.Categories.UpdateAsync(category);
                    await _unitOfWork.Commit();

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
