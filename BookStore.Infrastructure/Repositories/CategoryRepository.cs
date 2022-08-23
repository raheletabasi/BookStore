using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(BookStoreContext context) : base(context)
    {
    }
}
