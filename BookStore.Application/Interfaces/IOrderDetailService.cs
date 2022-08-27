using BookStore.Application.DTOs;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface IOrderDetailService
{
    Task<ResultOrderDetail> AddOrderDetail(OrderDetailViewModel orderDetailViewModel);
    Task<ResultOrderDetail> DeleteOrderDetail(Guid id);
    Task<ResultOrderDetail> UpdateOrderDetail(OrderDetailViewModel orderDetailViewModel);
    Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(Guid orderId);
}
