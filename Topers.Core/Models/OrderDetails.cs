namespace Topers.Core.Models;

public class OrderDetails
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
    /// Gets or sets a product count.
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    /// Gets or sets a product unit price.
    /// </summary>
    public double Price { get; set; }
}