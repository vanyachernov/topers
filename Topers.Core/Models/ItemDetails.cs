namespace Topers.Core.Models;

/// <summary>
/// Represents an item details.
/// </summary>
public class ItemDetails
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
}