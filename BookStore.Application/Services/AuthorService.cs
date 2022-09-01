using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<ResultAuthor> AddAuthor(AuthorViewModel authorViewModel)
    {
        try
        {
            var isDuplicate = await _authorRepository.IsDuplicate(authorViewModel.FirstName, authorViewModel.LastName);

            if (!isDuplicate)
            {
                var newAuthor = new Author()
                {
                    FirstName = authorViewModel.FirstName,
                    LastName = authorViewModel.LastName,
                    Email = authorViewModel.Email,
                };

                await _authorRepository.AddAsync(newAuthor);
                await _authorRepository.Save();

                return ResultAuthor.success;
            }
            return ResultAuthor.duplicate;
        }
        catch
        {
            return ResultAuthor.Error;
        }
    }

    public async Task<ResultAuthor> DeleteAuthor(Guid id)
    {
        try
        {
            var isExist = await _authorRepository.IsExist(id);
            if (isExist)
            {
                var author = await _authorRepository.GetByIdAsync(id);
                await _authorRepository.DeleteAsync(author);
                await _authorRepository.Save();

                return ResultAuthor.success;
            }
            return ResultAuthor.notFound;
        }
        catch
        {
            return ResultAuthor.Error;
        }
    }

    public List<Author> GetAllAuthors()
    {
        return _authorRepository.GetAllAsync();
    }

    public async Task<Author> GetAuthorById(Guid id)
    {
        return await _authorRepository.GetByIdAsync(id);
    }

    public async Task<ResultAuthor> UpdateAuthor(AuthorViewModel authorViewModel)
    {
        try
        {
            var isExist = await _authorRepository.IsExist(authorViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _authorRepository.IsDuplicate(
                    authorViewModel.Id, authorViewModel.FirstName, authorViewModel.LastName);

                if (!isDuplicate)
                {
                    var author = new Author()
                    {
                        FirstName = authorViewModel.FirstName,
                        LastName = authorViewModel.LastName,
                        Email = authorViewModel.Email
                    };

                    await _authorRepository.UpdateAsync(author);
                    await _authorRepository.Save();

                    return ResultAuthor.success;
                }
                return ResultAuthor.duplicate;
            }
            return ResultAuthor.notFound;
        }
        catch
        {
            return ResultAuthor.Error;
        }
    }
}
