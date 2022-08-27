using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
{
    Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(Guid orderId);
    Task<OrderDetail> CheckOrderDetail(Guid orderId, Guid bookId);
}
