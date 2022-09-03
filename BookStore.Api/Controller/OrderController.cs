using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("AddOrder")]
    public async Task<IActionResult> AddOrder(Guid userId, Guid bookId)
    {
        var result = await _orderService.AddOrder(userId, bookId);

        if (result == ResultOrder.Error) return BadRequest("Error In Add Order");

        return Ok("Success");
    }

    [HttpPut("ChangeOrderStatusToFinaly")]
    public async Task<IActionResult> ChangeOrderStatusToFinaly(Guid orderId)
    {
        var result = await _orderService.ChangeOrderStatusToFinaly(orderId);

        if (result == ResultOrder.notFound) return BadRequest("Order Is No Found");

        if (result == ResultOrder.Error) return BadRequest("Error In Update Order");

        return Ok("Success");
    }

    [HttpGet("GetOrderById")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var result = await _orderService.GetOrderById(id);
        return Ok(result);
    }

    [HttpPut("UpdateOrderPrice")]
    public async Task<IActionResult> UpdateOrderPrice(Guid orderId)
    {
        var result = await _orderService.UpdateOrderPrice(orderId);

        if (result == ResultOrder.notFound) return BadRequest("Order Is No Found");

        if (result == ResultOrder.Error) return BadRequest("Error In Update Order");

        return Ok("Success");
    }
}
