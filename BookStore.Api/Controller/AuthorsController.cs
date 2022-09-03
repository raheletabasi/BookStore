using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
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

        if (result == ResultAuthor.duplicate) return BadRequest("Author Is Duplicate");

        if (result == ResultAuthor.Error) return BadRequest("Error In Add Author");

        return Ok("Success");
    }

    [HttpPut("UpdateAuthor")]
    public async Task<IActionResult> UpdateAuthor(AuthorViewModel authorViewModel)
    {
        var result = await _authorService.UpdateAuthor(authorViewModel);

        if (result == ResultAuthor.duplicate) return BadRequest("Author Is Duplicate");

        if (result == ResultAuthor.notFound) return BadRequest("Auhor Is No Found");

        if (result == ResultAuthor.Error) return BadRequest("Error In Update Author");

        return Ok("Success");
    }

    [HttpDelete("DeleteAuthor")]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        var result = await _authorService.DeleteAuthor(id);

        if (result == ResultAuthor.notFound) return BadRequest("Auhor Is No Found");

        if (result == ResultAuthor.Error) return BadRequest("Error In Delete Author");

        return Ok("Success");
    }

    [HttpGet("GetAllAuthors")]
    public IActionResult GetAllAuthors()
    {
        var result = _authorService.GetAllAuthors();
        return Ok(result);
    }

    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetAuthorById(Guid id)
    {
        var result = await _authorService.GetAuthorById(id);
        return Ok(result);
    }
}
