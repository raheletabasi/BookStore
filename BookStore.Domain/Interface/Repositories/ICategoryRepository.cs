using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
}
