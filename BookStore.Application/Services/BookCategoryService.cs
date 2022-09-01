using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services;

public class BookCategoryService : IBookCategoryService
{
    private readonly IBookCategoryRepository _bookCategoryRepository;

    public BookCategoryService(IBookCategoryRepository bookCategoryRepository)
    {
        _bookCategoryRepository = bookCategoryRepository;
    }

    public async Task<ResultBookCategory> AddBookCategory(BookCategoryViewModel bookCategoryViewModel)
    {
        try
        {
            var isDuplicate = await _bookCategoryRepository.IsDuplicate(bookCategoryViewModel.BookId, bookCategoryViewModel.CategoryId);

            if (!isDuplicate)
            {
                var bookCategory = new BookCategory()
                {
                    BookId = bookCategoryViewModel.BookId,
                    CategoryId = bookCategoryViewModel.CategoryId
                };

                await _bookCategoryRepository.AddAsync(bookCategory);
                await _bookCategoryRepository.Save();

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
            var isExist = await _bookCategoryRepository.IsExist(id);
            if (isExist)
            {
                var bookCategory = await _bookCategoryRepository.GetByIdAsync(id);
                await _bookCategoryRepository.DeleteAsync(bookCategory);
                await _bookCategoryRepository.Save();

                return ResultBookCategory.success;
            }
            return ResultBookCategory.notFound;
        }
        catch
        {
            return ResultBookCategory.Error;
        }
    }

    public List<BookCategory> GetAllBookCategory()
    {
        return _bookCategoryRepository.GetAllAsync();
    }

    public async Task<BookCategory> GetBookCategoryById(Guid id)
    {
        return await _bookCategoryRepository.GetByIdAsync(id);
    }

    public async Task<ResultBookCategory> UpdateBookCategory(BookCategoryViewModel bookCategoryviewModel)
    {
        try
        {
            var isExist = await _bookCategoryRepository.IsExist(bookCategoryviewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _bookCategoryRepository.IsDuplicate(
                    bookCategoryviewModel.Id, bookCategoryviewModel.BookId, bookCategoryviewModel.CategoryId);

                if (!isDuplicate)
                {
                    var bookCategory = new BookCategory()
                    {
                        BookId = bookCategoryviewModel.BookId,
                        CategoryId = bookCategoryviewModel.CategoryId
                    };

                    await _bookCategoryRepository.UpdateAsync(bookCategory);
                    await _bookCategoryRepository.Save();

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
