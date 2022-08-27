using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Interface;

namespace BookStore.Application.Services;

public class OrderDetailService : IOrderDetailService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderDetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultOrderDetail> AddOrderDetail(OrderDetailViewModel orderDetailViewModel)
    {
        try
        {
            var orderDetail = new OrderDetail()
            {
                OrderId = orderDetailViewModel.OrderId,
                BookId = orderDetailViewModel.BookId,
                Qty = orderDetailViewModel.Qty,
                Price = orderDetailViewModel.Price,
            };

            await _unitOfWork.OrderDetails.AddAsync(orderDetail);
            await _unitOfWork.Commit();

            return ResultOrderDetail.success;
            
        }
        catch
        {
            return ResultOrderDetail.Error;
        }
    }

    public async Task<ResultOrderDetail> DeleteOrderDetail(Guid id)
    {
        try
        {
            var isExist = await _unitOfWork.OrderDetails.IsExist(id);
            if (isExist)
            {
                var orderDetail = await _unitOfWork.OrderDetails.GetByIdAsync(id);
                await _unitOfWork.OrderDetails.DeleteAsync(orderDetail);
                await _unitOfWork.Commit();

                return ResultOrderDetail.success;
            }
            return ResultOrderDetail.notFound;
        }
        catch
        {
            return ResultOrderDetail.Error;
        }
    }

    public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(Guid orderId)
    {
        return await _unitOfWork.OrderDetails.GetOrderDetailByOrderId(orderId);
    }

    public async Task<ResultOrderDetail> UpdateOrderDetail(OrderDetailViewModel orderDetailViewModel)
    {
        try
        {
            var isExist = await _unitOfWork.OrderDetails.IsExist(orderDetailViewModel.Id);
            if (isExist)
            {                
                var orderDetail = new OrderDetail()
                {
                    OrderId = orderDetailViewModel.OrderId,
                    BookId = orderDetailViewModel.BookId,
                    Qty = orderDetailViewModel.Qty,
                    Price = orderDetailViewModel.Price
                };

                await _unitOfWork.OrderDetails.UpdateAsync(orderDetail);
                await _unitOfWork.Commit();

                return ResultOrderDetail.success;                
            }
            return ResultOrderDetail.notFound;
        }
        catch
        {
            return ResultOrderDetail.Error;
        }
    }
}
