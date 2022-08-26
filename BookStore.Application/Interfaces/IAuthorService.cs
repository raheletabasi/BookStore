﻿using BookStore.Application.DTOs;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface IAuthorService
{
    Task<ResultAuthor> AddAuthor(AuthorViewModel authorViewModel);
    Task<ResultAuthor> UpdateAuthor(AuthorViewModel authorViewModel);
    Task<ResultAuthor> DeleteAuthor(Guid id);
    Task<Author> GetAuthorById(Guid id);
    Task<IEnumerable<Author>> GetAllAuthors();    
}

public enum ResultAuthor
{
    success,
    duplicate,
    notFound,
    Error
}
