using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
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

        if (result == Application.Interfaces.ResultBook.duplicate) return BadRequest("Book Is Duplicate");

        if (result == Application.Interfaces.ResultBook.Error) return BadRequest("Error In Add Book");

        return Ok("Success");
    }

    [HttpDelete("DeleteBook")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        var result = await _bookService.DeleteBook(id);

        if (result == Application.Interfaces.ResultBook.notFound) return BadRequest("Book Is No Found");

        if (result == Application.Interfaces.ResultBook.Error) return BadRequest("Error In Add Book");

        return Ok("Success");
    }

    [HttpGet("GetAllBookByAuthorId")]
    public async Task<IActionResult> GetAllBookByAuthorId(Guid authorId)
    {
        var result = await _bookService.GetAllBookByAuthorId(authorId);
        return Ok(result);
    }

    [HttpGet("GetAllBook")]
    public async Task<IActionResult> GetAllBooks()
    {
        var result = await _bookService.GetAllBooks();
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

        if (result == Application.Interfaces.ResultBook.duplicate) return BadRequest("Book Is Duplicate");

        if (result == Application.Interfaces.ResultBook.notFound) return BadRequest("Book Is No Found");

        if (result == Application.Interfaces.ResultBook.Error) return BadRequest("Error In Add Book");

        return Ok("Success");
    }
}
