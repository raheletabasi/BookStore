using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;

namespace BookStore.Application.Services;

public class BookCategoryService : IBookCategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookCategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultBookCategory> AddBookCategory(BookCategoryViewModel bookCategoryViewModel)
    {
        try
        {
            var isDuplicate = await _unitOfWork.BookCategories.IsDuplicate(bookCategoryViewModel.BookId, bookCategoryViewModel.CategoryId);

            if (!isDuplicate)
            {
                var bookCategory = new BookCategory()
                {
                    BookId = bookCategoryViewModel.BookId,
                    CategoryId = bookCategoryViewModel.CategoryId
                };

                await _unitOfWork.BookCategories.AddAsync(bookCategory);
                await _unitOfWork.Commit();

                return ResultBookCategory.success;
            }
            return ResultBookCategory.duplicate;
        }
        catch
        {
            return ResultBookCategory.Error;
        }
    }

    public async Task<ResultBookCategory> DeleteBookCategory(Guid id)
    {
        try
        {
            var isExist = await _unitOfWork.BookCategories.IsExist(id);
            if (isExist)
            {
                var bookCategory = await _unitOfWork.BookCategories.GetByIdAsync(id);
                await _unitOfWork.BookCategories.DeleteAsync(bookCategory);
                await _unitOfWork.Commit();

                return ResultBookCategory.success;
            }
            return ResultBookCategory.notFound;
        }
        catch
        {
            return ResultBookCategory.Error;
        }
    }

    public async Task<IEnumerable<BookCategory>> GetAllBookCategory()
    {
        return await _unitOfWork.BookCategories.GetAllAsync();
    }

    public async Task<BookCategory> GetBookCategoryById(Guid id)
    {
        return await _unitOfWork.BookCategories.GetByIdAsync(id);
    }

    public async Task<ResultBookCategory> UpdateBookCategory(BookCategoryViewModel bookCategoryviewModel)
    {
        try
        {
            var isExist = await _unitOfWork.BookCategories.IsExist(bookCategoryviewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _unitOfWork.BookCategories.IsDuplicate(
                    bookCategoryviewModel.Id, bookCategoryviewModel.BookId, bookCategoryviewModel.CategoryId);

                if (!isDuplicate)
                {
                    var bookCategory = new BookCategory()
                    {
                        BookId = bookCategoryviewModel.BookId,
                        CategoryId = bookCategoryviewModel.CategoryId
                    };

                    await _unitOfWork.BookCategories.UpdateAsync(bookCategory);
                    await _unitOfWork.Commit();

                    return ResultBookCategory.success;
                }
                return ResultBookCategory.duplicate;
            }
            return ResultBookCategory.notFound;
        }
        catch
        {
            return ResultBookCategory.Error;
        }
    }
}
