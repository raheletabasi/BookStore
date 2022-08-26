using BookStore.Application.DTOs;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface IBookCategoryService
{
    Task<ResultBookCategory> AddBookCategory(BookCategoryViewModel bookCategoryViewModel);
    Task<ResultBookCategory> UpdateBookCategory(BookCategoryViewModel bookCategoryviewModel);
    Task<ResultBookCategory> DeleteBookCategory(Guid id);
    Task<BookCategory> GetBookCategoryById(Guid id);
    Task<IEnumerable<BookCategory>> GetAllBookCategory();
}
