using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(BookStoreContext context) : base(context)
    {
    }
}
