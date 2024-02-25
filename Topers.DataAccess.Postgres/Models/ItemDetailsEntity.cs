namespace Topers.DataAccess.Postgres.Models;

/// <summary>
/// Represents an item details.
/// </summary>
public class ItemDetailsEntity
{
    /// <summary>
    /// Gets or sets an item details identifier.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets an item capacity.
    /// </summary>
    public int Capacity { get; set; }
    
    /// <summary>
    /// Gets or sets an item price.
    /// </summary>
    public double Price { get; set; }
    
    /// <summary>
    /// Gets or sets an item identifier.
    /// </summary>
    public Guid ItemId { get; set; }
    
    /// <summary>
    /// Gets or sets an item.
    /// </summary>
    public ItemEntity? Item { get; set; }
}