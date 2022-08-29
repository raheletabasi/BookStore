using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
{
    private readonly BookStoreContext _context;

    public OrderDetailRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<OrderDetail> CheckOrderDetail(Guid orderId, Guid bookId)
    {
        return await _context.OrderDetail.FirstOrDefaultAsync(c => c.OrderId == orderId && c.BookId.Equals(bookId) && !c.IsDeleted);
    }

    public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(Guid orderId)
    {
        return await Task.FromResult(_context.OrderDetail.Where(x => x.OrderId.Equals(orderId)));
    }
}
