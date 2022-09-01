using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services;

public class OrderDetailService : IOrderDetailService
{
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderDetailService(IOrderDetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
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

            await _orderDetailRepository.AddAsync(orderDetail);
            await _orderDetailRepository.Save();

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
            var isExist = await _orderDetailRepository.IsExist(id);
            if (isExist)
            {
                var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
                await _orderDetailRepository.DeleteAsync(orderDetail);
                await _orderDetailRepository.Save();

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
        return await _orderDetailRepository.GetOrderDetailByOrderId(orderId);
    }

    public async Task<ResultOrderDetail> UpdateOrderDetail(OrderDetailViewModel orderDetailViewModel)
    {
        try
        {
            var isExist = await _orderDetailRepository.IsExist(orderDetailViewModel.Id);
            if (isExist)
            {                
                var orderDetail = new OrderDetail()
                {
                    OrderId = orderDetailViewModel.OrderId,
                    BookId = orderDetailViewModel.BookId,
                    Qty = orderDetailViewModel.Qty,
                    Price = orderDetailViewModel.Price
                };

                await _orderDetailRepository.UpdateAsync(orderDetail);
                await _orderDetailRepository.Save();

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
