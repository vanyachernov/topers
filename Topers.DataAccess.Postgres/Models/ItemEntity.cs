namespace Topers.DataAccess.Postgres.Models;

/// <summary>
/// Represents an item.
/// </summary>
public class ItemEntity
{
    /// <summary>
    /// Gets or sets an item identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets an item name.
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets an item description.
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets an item category identifier.
    /// </summary>
    public Guid CategoryId { get; set; }
    
    /// <summary>
    /// Gets or sets an item category.
    /// </summary>
    public CategoryEntity? Category { get; set; }

    /// <summary>
    /// Gets or sets an item details list.
    /// </summary>
    public List<ItemDetails> Details { get; set; } = [];
}