using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
{
    public Task AddToOrderDetail(OrderDetail orderDetail);
    public Task UpdateOrderDetail(OrderDetail orderDetail);
}
