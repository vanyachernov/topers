using Microsoft.AspNetCore.Mvc;
using Topers_API.Contracts;
using Topers.Core.Abstractions;
using Topers.Core.Models;

namespace Topers_API.Controllers;

[ApiController]
[Route("api/items")]
public class ItemsController(IItemsService itemsService) : ControllerBase
{
    /// <summary>
    /// Get all items.
    /// </summary>
    /// <returns>Items list.</returns>
    [HttpGet]
    public async Task<ActionResult<List<ItemsResponse>>> GetItems()
    {
        var items = await itemsService.GetAllItems();

        var response = items.Select(i => new ItemsResponse(i.Id, i.Title, i.Description, i.CategoryId));

        return Ok(response);
    }
    
    /// <summary>
    /// Get item by identifier.
    /// </summary>
    /// <param name="id">Item identifier.</param>
    /// <returns>Item.</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<List<ItemsResponse>>> GetItem(Guid id)
    {
        var item = await itemsService.GetItemById(id);
        return Ok(item);
    }
    
    /// <summary>
    /// Get category items.
    /// </summary>
    /// <param name="id">Category identifier.</param>
    /// <returns>Category items.</returns>
    [HttpGet("category/{id:guid}")]
    public async Task<ActionResult<List<ItemsResponse>>> GetItemsByCategoryId(Guid id)
    {
        var categoryItems = await itemsService.GetItemsByCategoryId(id);

        var response = categoryItems.Select(b => new ItemsResponse(b.Id, b.Title, b.Description, b.CategoryId));
        
        return Ok(response);
    }
    
    /// <summary>
    /// Create a new item.
    /// </summary>
    /// <param name="request">New item body.</param>
    /// <returns>A new item identifier.</returns>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateItem([FromBody] ItemsRequest request)
    {
        var (item, error) = Item.Create(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.CategoryId);

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var itemId = await itemsService.CreateItem(item);
        
        return Ok(itemId);
    }
    
    /// <summary>
    /// Update an exists item.
    /// </summary>
    /// <param name="id">Item identifier.</param>
    /// <param name="request">An exists item body.</param>
    /// <returns>A new item identifier.</returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateItem(Guid id, [FromBody] ItemsRequest request)
    {
        var (newItemModel, error) = 
            Item.Create(
                id,
                request.Title,
                request.Description,
                request.CategoryId
            );
        
        var itemId = await itemsService.UpdateItem(newItemModel);

        return Ok(itemId);
    }
    
    /// <summary>
    /// Delete item.
    /// </summary>
    /// <param name="id">Item identifier.</param>
    /// <returns>A deleted item identifier.</returns>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteItem(Guid id)
    {
        return Ok(await itemsService.DeleteItem(id));
    }
}