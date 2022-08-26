using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;

namespace BookStore.Application.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Interfaces.ResultBook> AddBook(BookViewModel bookViewModel)
    {
        try
        {
            var isDuplicate = await _unitOfWork.Books.IsDuplicate(
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

                await _unitOfWork.Books.AddAsync(book);
                await _unitOfWork.Commit();

                return Interfaces.ResultBook.success;
            }
            return Interfaces.ResultBook.duplicate;
        }
        catch
        {
            return Interfaces.ResultBook.Error;
        }
    }

    public async Task<Interfaces.ResultBook> DeleteBook(Guid id)
    {
        try
        {
            var isExist = await _unitOfWork.Books.IsExist(id);
            if (isExist)
            {
                var author = await _unitOfWork.Books.GetByIdAsync(id);
                await _unitOfWork.Books.DeleteAsync(author);
                await _unitOfWork.Commit();

                return Interfaces.ResultBook.success;
            }
            return Interfaces.ResultBook.notFound;
        }
        catch
        {
            return Interfaces.ResultBook.Error;
        }
    }

    public async Task<IEnumerable<Book>> GetAllBookByAuthorId(Guid id)
    {
        var listOfBook = await _unitOfWork.Books.GetAllAsync();
        return listOfBook.Where(x => x.AuthorId.Equals(id));
    }

    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        return await _unitOfWork.Books.GetAllAsync();
    }

    public async Task<Book> GetBookById(Guid id)
    {
        return await _unitOfWork.Books.GetByIdAsync(id);
    }

    public async Task<Interfaces.ResultBook> UpdateBook(BookViewModel bookViewModel)
    {
        try
        {
            var isExist = await _unitOfWork.Books.IsExist(bookViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _unitOfWork.Books.IsDuplicate(
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

                    await _unitOfWork.Books.UpdateAsync(book);
                    await _unitOfWork.Commit();

                    return Interfaces.ResultBook.success;
                }
                return Interfaces.ResultBook.duplicate;
            }
            return Interfaces.ResultBook.notFound;
        }
        catch
        {
            return Interfaces.ResultBook.Error;
        }
    }
}
