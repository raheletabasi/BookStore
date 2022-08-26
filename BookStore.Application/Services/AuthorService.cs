using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;

namespace BookStore.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Interfaces.ResultAuthor> AddAuthor(AuthorViewModel authorViewModel)
    {
        try
        {
            var isDuplicate = await _unitOfWork.Authors.IsDuplicate(authorViewModel.FirstName, authorViewModel.LastName);

            if (!isDuplicate)
            {
                var newAuthor = new Author()
                {
                    FirstName = authorViewModel.FirstName,
                    LastName = authorViewModel.LastName,
                    Email = authorViewModel.Email,
                };

                await _unitOfWork.Authors.AddAsync(newAuthor);
                await _unitOfWork.Commit();

                return Interfaces.ResultAuthor.success;
            }
            return Interfaces.ResultAuthor.duplicate;
        }
        catch
        {
            return Interfaces.ResultAuthor.Error;
        }
    }

    public async Task<Interfaces.ResultAuthor> DeleteAuthor(Guid id)
    {
        try
        {
            var isExist = await _unitOfWork.Authors.IsExist(id);
            if (isExist)
            {
                var author = await _unitOfWork.Authors.GetByIdAsync(id);
                await _unitOfWork.Authors.DeleteAsync(author);
                await _unitOfWork.Commit();

                return Interfaces.ResultAuthor.success;
            }
            return Interfaces.ResultAuthor.notFound;
        }
        catch
        {
            return Interfaces.ResultAuthor.Error;
        }
    }

    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        return await _unitOfWork.Authors.GetAllAsync();
    }

    public async Task<Author> GetAuthorById(Guid id)
    {
        return await _unitOfWork.Authors.GetByIdAsync(id);
    }

    public async Task<Interfaces.ResultAuthor> UpdateAuthor(AuthorViewModel authorViewModel)
    {
        try
        {
            var isExist = await _unitOfWork.Authors.IsExist(authorViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _unitOfWork.Authors.IsDuplicate(
                    authorViewModel.Id, authorViewModel.FirstName, authorViewModel.LastName);

                if (!isDuplicate)
                {
                    var author = new Author()
                    {
                        FirstName = authorViewModel.FirstName,
                        LastName = authorViewModel.LastName,
                        Email = authorViewModel.Email
                    };

                    await _unitOfWork.Authors.UpdateAsync(author);
                    await _unitOfWork.Commit();

                    return Interfaces.ResultAuthor.success;
                }
                return Interfaces.ResultAuthor.duplicate;
            }
            return Interfaces.ResultAuthor.notFound;
        }
        catch
        {
            return Interfaces.ResultAuthor.Error;
        }
    }
}
