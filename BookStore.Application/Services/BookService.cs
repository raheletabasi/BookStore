using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ResultBook> AddBook(BookViewModel bookViewModel)
    {
        try
        {
            var isDuplicate = await _bookRepository.IsDuplicate(
                bookViewModel.Name, bookViewModel.AuthorId, bookViewModel.PublisherId);

            if (!isDuplicate)
            {
                var book = new Book()
                {
                    Name = bookViewModel.Name,
                    AuthorId = bookViewModel.AuthorId,
                    PublisherId = bookViewModel.PublisherId,
                    Description = bookViewModel.Description,
                    Price = bookViewModel.Price,
                    IsActive = true
                };

                await _bookRepository.AddAsync(book);
                await _bookRepository.Save();

                return ResultBook.success;
            }
            return ResultBook.duplicate;
        }
        catch
        {
            return ResultBook.Error;
        }
    }

    public async Task<ResultBook> DeleteBook(Guid id)
    {
        try
        {
            var isExist = await _bookRepository.IsExist(id);
            if (isExist)
            {
                var book = await _bookRepository.GetByIdAsync(id);
                await _bookRepository.DeleteAsync(book);
                await _bookRepository.Save();

                return ResultBook.success;
            }
            return ResultBook.notFound;
        }
        catch
        {
            return ResultBook.Error;
        }
    }

    public async Task<IEnumerable<Book>> GetAllBookByAuthorId(Guid id)
    {
        var listOfBook = _bookRepository.GetAllAsync();
        return listOfBook.Where(x => x.AuthorId.Equals(id));
    }

    public List<Book> GetAllBooks()
    {
        return  _bookRepository.GetAllAsync();
    }

    public async Task<Book> GetBookById(Guid id)
    {
        return await _bookRepository.GetByIdAsync(id);
    }

    public async Task<ResultBook> UpdateBook(BookViewModel bookViewModel)
    {
        try
        {
            var isExist = await _bookRepository.IsExist(bookViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _bookRepository.IsDuplicate(
                    bookViewModel.Id, bookViewModel.Name, bookViewModel.AuthorId, bookViewModel.PublisherId);

                if (!isDuplicate)
                {
                    var book = new Book()
                    {
                        Name = bookViewModel.Name,
                        AuthorId = bookViewModel.AuthorId,
                        PublisherId = bookViewModel.PublisherId,
                        Description = bookViewModel.Description,
                        Price = bookViewModel.Price,
                        IsActive = bookViewModel.IsActive
                    };

                    await _bookRepository.UpdateAsync(book);
                    await _bookRepository.Save();

                    return ResultBook.success;
                }
                return ResultBook.duplicate;
            }
            return ResultBook.notFound;
        }
        catch
        {
            return ResultBook.Error;
        }
    }
}
