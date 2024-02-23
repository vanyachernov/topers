using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Topers_API.Contracts;
using Topers.Core.Abstractions;
using Topers.Core.Models;

namespace Topers_API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController(ICategoriesService categoriesService) : ControllerBase
{
    /// <summary>
    /// Get category list.
    /// </summary>
    /// <returns>Category list.</returns>
    [HttpGet]
    public async Task<ActionResult<List<CategoriesResponse>>> GetCategories()
    {
        var categories = await categoriesService.GetAllCategories();

        var response = categories.Select(b => new CategoriesResponse(b.Id, b.Title, b.Description));

        return Ok(response);
    }

    /// <summary>
    /// Get category by identifier.
    /// </summary>
    /// <param name="id">Category identifier.</param>
    /// <returns>Category.</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoriesResponse>> GetCategory(Guid id)
    {
        var category = await categoriesService.GetCategoryById(id);
        return Ok(category);
    }

    /// <summary>
    /// Create a new category.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>New category.</returns>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateCategory([FromBody] CategoriesRequest request)
    {
        var (category, error) = Category.Create(
            Guid.NewGuid(),
            request.Title,
            request.Description);

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var categoryId = await categoriesService.CreateCategory(category);
        
        return Ok(categoryId);
    }

    /// <summary>
    /// Update an exist category.
    /// </summary>
    /// <param name="id">Category identifier.</param>
    /// <param name="request">An exist category body.</param>
    /// <returns>A new category identifier.</returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateCategory(Guid id, [FromBody] CategoriesRequest request)
    {
        var (newCategoryModel, error) = 
            Category.Create(
                id,
                request.Title,
                request.Description
            );
        
        var categoryId = await categoriesService.UpdateCategory(newCategoryModel);

        return Ok(categoryId);
    }

    /// <summary>
    /// Delete category.
    /// </summary>
    /// <param name="id">Category identifier.</param>
    /// <returns>A deleted category identifier.</returns>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteCategory(Guid id)
    {
        return Ok(await categoriesService.DeleteCategory(id));
    }
}