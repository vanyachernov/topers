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
}