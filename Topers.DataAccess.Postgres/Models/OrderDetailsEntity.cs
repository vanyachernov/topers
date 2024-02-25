namespace Topers.DataAccess.Postgres.Models;

/// <summary>
/// Represents an order details.
/// </summary>
public class OrderDetailsEntity
{
    /// <summary>
    /// Gets or sets an order identifier.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets an order identifier.
    /// </summary>
    public Guid OrderId { get; set; }
    
    /// <summary>
    /// Gets or sets an order.
    /// </summary>
    public OrderEntity? Order { get; set; }
    
    /// <summary>
    /// Gets or sets an item identifier.
    /// </summary>
    public Guid ItemId { get; set; }

    /// <summary>
    /// Gets or sets an item.
    /// </summary>
    public ItemEntity? Item { get; set; }
    
    /// <summary>
    /// Gets or sets a product count.
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    /// Gets or sets a product unit price.
    /// </summary>
    public double Price { get; set; }
}