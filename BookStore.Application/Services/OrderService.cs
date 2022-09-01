using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderService(IOrderRepository orderRepository, IBookRepository bookRepository, IOrderDetailRepository orderDetailRepository)
    {
        _orderRepository = orderRepository;
        _bookRepository = bookRepository;
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<ResultOrder> AddOrder(Guid userId, Guid bookId)
    {
        try
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            var order = await _orderRepository.CheckUserOrder(userId);

            if (order == null)
            {
                order = new Order()
                {
                    UserId = userId,
                    IsFinaly = false,
                    OrderSum = book.Price,                   
                };

                await _orderRepository.AddAsync(order);

                var orderDetail = new OrderDetail()
                {
                    OrderId = order.Id,
                    BookId = bookId,
                    Price = book.Price,
                    Qty = 1
                };
                
                await _orderDetailRepository.AddAsync(orderDetail);
                await _orderDetailRepository.Save();

                return ResultOrder.success;
            }
            else
            {
                var detail = await _orderDetailRepository.CheckOrderDetail(order.Id, book.Id);
                if (detail != null)
                {
                    detail.Qty += 1;
                    await _orderDetailRepository.AddAsync(detail);
                }
                else
                {
                    detail = new OrderDetail()
                    {
                        OrderId = order.Id,
                        Qty = 1,
                        BookId = bookId,
                        Price = book.Price
                    };
                    await _orderDetailRepository.AddAsync(detail);
                }

                await _orderDetailRepository.Save();

                return ResultOrder.success;
            }
        }
        catch
        {
            return ResultOrder.Error;
        }
    }

    public async Task<ResultOrder> ChangeOrderStatusToFinaly(Guid orderId)
    {
        try
        {
            var isExist = await _orderRepository.IsExist(orderId);
            if (isExist)
            {
                var order = await _orderRepository.GetByIdAsync(orderId);
                order.IsFinaly = true;

                await _orderRepository.UpdateAsync(order);
                await _orderRepository.Save();

                return ResultOrder.success;
            }
            return ResultOrder.notFound;
        }
        catch
        {
            return ResultOrder.Error;
        }
    }

    public async Task<Order> GetOrderById(Guid orderId)
    {
        return await _orderRepository.GetByIdAsync(orderId);
    }

    public async Task<ResultOrder> UpdateOrderPrice(Guid orderId)
    {
        try
        {
            var isExist = await _orderRepository.IsExist(orderId);
            if(isExist)
            {
                var order = await _orderRepository.GetByIdAsync(orderId);
                order.OrderSum = await _orderRepository.OrderSum(orderId);

                await _orderRepository.UpdateAsync(order);
                await _orderRepository.Save();

                return ResultOrder.success;
            }
            return ResultOrder.notFound;
        }
        catch
        {
            return ResultOrder.Error;
        }
    }
}
