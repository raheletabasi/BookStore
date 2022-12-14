using BookStore.Application.DTOs;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface IBookService
{
    Task<ResultBook> AddBook(BookViewModel bookViewModel);
    Task<ResultBook> UpdateBook(BookViewModel bookViewModel);
    Task<ResultBook> DeleteBook(Guid id);
    Task<Book> GetBookById(Guid id);
    List<Book> GetAllBooks();
    Task<IEnumerable<Book>> GetAllBookByAuthorId(Guid id);
}