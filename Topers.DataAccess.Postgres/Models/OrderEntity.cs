using System.ComponentModel.DataAnnotations;

namespace Topers.DataAccess.Postgres.Models;

/// <summary>
/// Represents an order header.
/// </summary>
public class OrderEntity
{
    /// <summary>
    /// Gets or sets an order identifier.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets an order date.
    /// </summary>
    public DateTime OrderDate { get; set; }
    
    /// <summary>
    /// Gets or sets an order pickup date.
    /// </summary>
    public DateTime DateOfPick { get; set; }
    
    /// <summary>
    /// Gets or sets an order pickup time.
    /// </summary>
    public DateTime TimeOfPick { get; set; }
    
    /// <summary>
    /// Gets or sets an order subtotal.
    /// </summary>
    public double SubTotal { get; set; }
    
    /// <summary>
    /// Gets or sets an order total.
    /// </summary>
    public double OrderTotal { get; set; }

    /// <summary>
    /// Gets or sets an order status.
    /// </summary>
    public string OrderStatus { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets an order payment status.
    /// </summary>
    public string PaymentStatus { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets an order details list.
    /// </summary>
    public List<OrderDetailsEntity> Details { get; set; } = [];
}