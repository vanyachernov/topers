namespace Topers.Core.Models;

/// <summary>
/// Represents an item.
/// </summary>
public class Item
{
    /// <summary>
    /// Gets a max length of item value.
    /// </summary>
    public const int MAX_TITLE_LENGTH = 250;
    
    private Item(Guid id, string title, string description, Guid categoryId)
    {
        Id = id;
        Title = title;
        Description = description;
        CategoryId = categoryId;
    }
    
    /// <summary>
    /// Gets or sets an item identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets an item name.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Gets or sets an item description.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Gets or sets an item category identifier.
    /// </summary>
    public Guid CategoryId { get; set; }
    
    /// <summary>
    /// Creates a instance of the Item.
    /// </summary>
    /// <param name="id">Item identifier.</param>
    /// <param name="title">Item title.</param>
    /// <param name="description">Item description.</param>
    /// <param name="categoryId">Category identifier.</param>
    /// <returns>New Item cartage.</returns>
    public static (Item Item, string error) Create(Guid id, string title, string description, Guid categoryId)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
        {
            error = "Title can not be empty or longer then 250 symbols";
        }

        var item = new Item(id, title, description, categoryId);

        return (item, error);
    }
}