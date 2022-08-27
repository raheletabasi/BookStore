using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;

    public OrderDetailController(IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
    }

    [HttpPost("AddOrderDetail")]
    public async Task<IActionResult> AddOrderDetail(OrderDetailViewModel orderDetailViewModel)
    {
        var result = await _orderDetailService.AddOrderDetail(orderDetailViewModel);

        if (result == ResultOrderDetail.Error) return BadRequest("Error In Add OrderDetail");

        return Ok("Success");
    }

    [HttpDelete("DeleteOrderDetail")]
    public async Task<IActionResult> DeleteOrderDetail(Guid id)
    {
        var result = await _orderDetailService.DeleteOrderDetail(id);

        if (result == ResultOrderDetail.notFound) return BadRequest("Order Detail Is No Found");

        if (result == ResultOrderDetail.Error) return BadRequest("Error In Delete Order Detail");

        return Ok("Success");
    }

    [HttpGet("GetOrderDetailByOrderId")]
    public async Task<IActionResult> GetOrderDetailByOrderId(Guid id)
    {
        var result = await _orderDetailService.GetOrderDetailByOrderId(id);
        return Ok(result);
    }

    [HttpPut("UpdateOrderDetail")]
    public async Task<IActionResult> UpdateOrderDetail(OrderDetailViewModel orderDetailViewModel)
    {
        var result = await _orderDetailService.UpdateOrderDetail(orderDetailViewModel);

        if (result == ResultOrderDetail.notFound) return BadRequest("Order Detail Is No Found");

        if (result == ResultOrderDetail.Error) return BadRequest("Error In Update Order Detail");

        return Ok("Success");
    }
}
