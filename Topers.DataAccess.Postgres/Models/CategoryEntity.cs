using System.ComponentModel.DataAnnotations;

namespace Topers.DataAccess.Postgres.Models;

/// <summary>
/// Represents a category.
/// </summary>
public class CategoryEntity
{
    /// <summary>
    /// Gets or sets a category identifier.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets a category name.
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets a category description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets an category items.
    /// </summary>
    public List<ItemEntity> Items { get; set; } = [];
}