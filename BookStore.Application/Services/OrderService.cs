using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;

namespace BookStore.Application.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultOrder> AddOrder(Guid userId, Guid bookId)
    {
        try
        {
            var book = await _unitOfWork.Books.GetByIdAsync(bookId);
            var order = await _unitOfWork.Orders.CheckUserOrder(userId);

            if (order == null)
            {
                order = new Order()
                {
                    UserId = userId,
                    IsFinaly = false,
                    OrderSum = book.Price,                   
                };

                await _unitOfWork.Orders.AddAsync(order);

                var orderDetail = new OrderDetail()
                {
                    OrderId = order.Id,
                    BookId = bookId,
                    Price = book.Price,
                    Qty = 1
                };
                
                await _unitOfWork.OrderDetails.AddAsync(orderDetail);
                await _unitOfWork.Commit();

                return ResultOrder.success;
            }
            else
            {
                var detail = await _unitOfWork.OrderDetails.CheckOrderDetail(order.Id, book.Id);
                if (detail != null)
                {
                    detail.Qty += 1;
                    await _unitOfWork.OrderDetails.AddAsync(detail);
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
                    await _unitOfWork.OrderDetails.AddAsync(detail);
                }

                await _unitOfWork.Commit();

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
            var isExist = await _unitOfWork.Orders.IsExist(orderId);
            if (isExist)
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
                order.IsFinaly = true;

                await _unitOfWork.Orders.UpdateAsync(order);
                await _unitOfWork.Commit();

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
        return await _unitOfWork.Orders.GetByIdAsync(orderId);
    }

    public async Task<ResultOrder> UpdateOrderPrice(Guid orderId)
    {
        try
        {
            var isExist = await _unitOfWork.Orders.IsExist(orderId);
            if(isExist)
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
                order.OrderSum = await _unitOfWork.Orders.OrderSum(orderId);

                await _unitOfWork.Orders.UpdateAsync(order);
                await _unitOfWork.Commit();

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
