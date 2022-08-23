using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(BookStoreContext context) : base(context)
    {
    }
}
