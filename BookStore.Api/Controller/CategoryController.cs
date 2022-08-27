using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategory(CategoryViewModel categoryViewModel)
    {
        var result = await _categoryService.AddCategory(categoryViewModel);

        if (result == ResultCategory.duplicate) return BadRequest("Category Is Duplicate");

        if (result == ResultCategory.Error) return BadRequest("Error In Add Category");

        return Ok("Success");
    }

    [HttpDelete("DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var result = await _categoryService.DeleteCategory(id);

        if (result == ResultCategory.notFound) return BadRequest("Category Is No Found");

        if (result == ResultCategory.Error) return BadRequest("Error In Delete Category");

        return Ok("Success");
    }

    [HttpGet("GetAllCategory")]
    public async Task<IActionResult> GetAllCategory()
    {
        var result = await _categoryService.GetAllCategory();
        return Ok(result);
    }

    [HttpGet("GetCategoryById")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var result = await _categoryService.GetCategoryById(id);
        return Ok(result);
    }

    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> UpdateCategory(CategoryViewModel categoryViewModel)
    {
        var result = await _categoryService.UpdateCategory(categoryViewModel);

        if (result == ResultCategory.duplicate) return BadRequest("Category Is Duplicate");

        if (result == ResultCategory.notFound) return BadRequest("Category Is No Found");

        if (result == ResultCategory.Error) return BadRequest("Error In Update Category");

        return Ok("Success");
    }
}
