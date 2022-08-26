using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost("AddAuthor")]
    public async Task<IActionResult> AddAuthor(AuthorViewModel authorViewModel)
    {
        var result = await _authorService.AddAuthor(authorViewModel);

        if (result == Application.Interfaces.ResultAuthor.duplicate) return BadRequest("Author Is Duplicate");

        if (result == Application.Interfaces.ResultAuthor.Error) return BadRequest("Error In Add Author");

        return Ok("Success");
    }

    [HttpPut("UpdateAuthor")]
    public async Task<IActionResult> UpdateAuthor(AuthorViewModel authorViewModel)
    {
        var result = await _authorService.UpdateAuthor(authorViewModel);

        if (result == Application.Interfaces.ResultAuthor.duplicate) return BadRequest("Author Is Duplicate");

        if (result == Application.Interfaces.ResultAuthor.notFound) return BadRequest("Auhor Is No Found");

        if (result == Application.Interfaces.ResultAuthor.Error) return BadRequest("Error In Add Author");

        return Ok("Success");
    }

    [HttpDelete("DeleteAuthor")]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        var result = await _authorService.DeleteAuthor(id);

        if (result == Application.Interfaces.ResultAuthor.notFound) return BadRequest("Auhor Is No Found");

        if (result == Application.Interfaces.ResultAuthor.Error) return BadRequest("Error In Add Author");

        return Ok("Success");
    }

    [HttpGet("GetAllAuthors")]
    public async Task<IActionResult> GetAllAuthors()
    {
        var result = await _authorService.GetAllAuthors();
        return Ok(result);
    }

    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetAuthorById(Guid id)
    {
        var result = await _authorService.GetAuthorById(id);
        return Ok(result);
    }
}
