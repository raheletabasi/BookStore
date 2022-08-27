using BookStore.Application.DTOs;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface IOrderService
{
    Task<ResultOrder> AddOrder(Guid userId, Guid bookId);
    Task<Order> GetOrderById(Guid orderId);
    Task<ResultOrder> ChangeOrderStatusToFinaly(Guid orderId);
    Task<ResultOrder> UpdateOrderPrice (Guid orderId);
}
