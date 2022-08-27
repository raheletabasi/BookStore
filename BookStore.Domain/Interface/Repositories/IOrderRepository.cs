using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<decimal> OrderSum(Guid orderId);
        Task<Order> CheckUserOrder(Guid userId);
    }
}
