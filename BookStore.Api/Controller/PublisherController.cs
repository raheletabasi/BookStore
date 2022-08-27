using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpPost("AddPublisher")]
    public async Task<IActionResult> AddPublisher(PublisherViewModel publisherViewModel)
    {
        var result = await _publisherService.AddPublisher(publisherViewModel);

        if (result == ResultPublisher.duplicate) return BadRequest("Publisher Is Duplicate");

        if (result == ResultPublisher.Error) return BadRequest("Error In Add Publisher");

        return Ok("Success");
    }

    [HttpPut("UpdatePublisher")]
    public async Task<IActionResult> UpdatePublisher(PublisherViewModel publisherViewModel)
    {
        var result = await _publisherService.UpdatePublisher(publisherViewModel);

        if (result == ResultPublisher.duplicate) return BadRequest("Publisher Is Duplicate");

        if (result == ResultPublisher.notFound) return BadRequest("Publisher Is No Found");

        if (result == ResultPublisher.Error) return BadRequest("Error In Update Publisher");

        return Ok("Success");
    }

    [HttpDelete("DeletePublisher")]
    public async Task<IActionResult> DeletePublisher(Guid id)
    {
        var result = await _publisherService.DeletePublisher(id);

        if (result == ResultPublisher.notFound) return BadRequest("Publisher Is No Found");

        if (result == ResultPublisher.Error) return BadRequest("Error In Delete Publisher");

        return Ok("Success");
    }

    [HttpGet("GetAllPublishers")]
    public async Task<IActionResult> GetAllPublishers()
    {
        var result = await _publisherService.GetAllPublishers();
        return Ok(result);
    }

    [HttpGet("GetPublisherById")]
    public async Task<IActionResult> GetPublisherById(Guid id)
    {
        var result = await _publisherService.GetPublisherById(id);
        return Ok(result);
    }
}
