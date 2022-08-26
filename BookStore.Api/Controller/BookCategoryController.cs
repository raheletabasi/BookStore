using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class BookCategoryController : ControllerBase
{
    private readonly IBookCategoryService _bookCategoryService;

    public BookCategoryController(IBookCategoryService bookCategoryService)
    {
        _bookCategoryService = bookCategoryService;
    }

    [HttpPost("AddBookCategory")]
    public async Task<IActionResult> AddBookCategory(BookCategoryViewModel bookCategoryViewModel)
    {
        var result = await _bookCategoryService.AddBookCategory(bookCategoryViewModel);

        if (result == ResultBookCategory.duplicate) return BadRequest("Book Category Is Duplicate");

        if (result == ResultBookCategory.Error) return BadRequest("Error In Add Book Category");

        return Ok("Success");
    }

    [HttpDelete("DeleteBookCategory")]
    public async Task<IActionResult> DeleteBookCategory(Guid id)
    {
        var result = await _bookCategoryService.DeleteBookCategory(id);

        if (result == ResultBookCategory.notFound) return BadRequest("Book Category Is No Found");

        if (result == ResultBookCategory.Error) return BadRequest("Error In Delete Book Category");

        return Ok("Success");
    }

    [HttpGet("GetAllBookCategory")]
    public async Task<IActionResult> GetAllBookCategory()
    {
        var result = await _bookCategoryService.GetAllBookCategory();
        return Ok(result);
    }

    [HttpGet("GetBookCategoryById")]
    public async Task<IActionResult> GetBookCategoryById(Guid id)
    {
        var result = await _bookCategoryService.GetBookCategoryById(id);
        return Ok(result);
    }

    [HttpPut("UpdateBookCategory")]
    public async Task<IActionResult> UpdateBookCategory(BookCategoryViewModel bookCategoryViewModel)
    {
        var result = await _bookCategoryService.UpdateBookCategory(bookCategoryViewModel);

        if (result == ResultBookCategory.duplicate) return BadRequest("Book Category Is Duplicate");

        if (result == ResultBookCategory.notFound) return BadRequest("Book Category Is No Found");

        if (result == ResultBookCategory.Error) return BadRequest("Error In Update Book Category");

        return Ok("Success");
    }
}
