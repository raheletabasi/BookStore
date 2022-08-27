using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

internal class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
{
    private readonly BookStoreContext _context;

    public OrderDetailRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(Guid orderId)
    {
        return await Task.FromResult(_context.OrderDetail.Where(x => x.OrderId.Equals(orderId)));
    }
}
