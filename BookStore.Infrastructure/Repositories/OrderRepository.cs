using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.GenericRepository;

namespace BookStore.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly BookStoreContext _context;

    public OrderRepository(BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Order> CheckUserOrder(Guid userId)
    {
        return await Task.FromResult(_context.Order.FirstOrDefault(x => x.UserId.Equals(userId) && !x.IsFinaly));
    }

    public async Task<decimal> OrderSum(Guid orderId)
    {
        return await Task.FromResult(_context.OrderDetail.Where(x => x.OrderId.Equals(orderId)).Sum(x => x.Price));
    }
}
