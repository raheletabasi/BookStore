using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("AddBook")]
    public async Task<IActionResult> AddBook(BookViewModel bookViewModel)
    {
        var result = await _bookService.AddBook(bookViewModel);

        if (result == ResultBook.duplicate) return BadRequest("Book Is Duplicate");

        if (result == ResultBook.Error) return BadRequest("Error In Add Book");

        return Ok("Success");
    }

    [HttpDelete("DeleteBook")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        var result = await _bookService.DeleteBook(id);

        if (result == ResultBook.notFound) return BadRequest("Book Is No Found");

        if (result == ResultBook.Error) return BadRequest("Error In Delete Book");

        return Ok("Success");
    }

    [HttpGet("GetAllBookByAuthorId")]
    public async Task<IActionResult> GetAllBookByAuthorId(Guid authorId)
    {
        var result = await _bookService.GetAllBookByAuthorId(authorId);
        return Ok(result);
    }

    [HttpGet("GetAllBook")]
    public IActionResult GetAllBooks()
    {
        var result = _bookService.GetAllBooks();
        return Ok(result);
    }

    [HttpGet("GetBookById")]
    public async Task<IActionResult> GetBookById(Guid id)
    {
        var result = await _bookService.GetBookById(id);
        return Ok(result);
    }

    [HttpPut("UpdateBook")]
    public async Task<IActionResult> UpdateBook(BookViewModel bookViewModel)
    {
        var result = await _bookService.UpdateBook(bookViewModel);

        if (result == ResultBook.duplicate) return BadRequest("Book Is Duplicate");

        if (result == ResultBook.notFound) return BadRequest("Book Is No Found");

        if (result == ResultBook.Error) return BadRequest("Error In Update Book");

        return Ok("Success");
    }
}
