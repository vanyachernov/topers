namespace Topers.Core.Models;

/// <summary>
/// Represents a category.
/// </summary>
public class Category
{
    /// <summary>
    /// Gets a max length of category value.
    /// </summary>
    public const int MAX_TITLE_LENGTH = 250;
    
    private Category(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
    
    /// <summary>
    /// Gets or sets a category identifier.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets a category name.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Gets or sets a category description.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Creates a instance of the category.
    /// </summary>
    /// <param name="id">Category identifier.</param>
    /// <param name="title">Category title.</param>
    /// <param name="description">Category description.</param>
    /// <returns>New category cartage.</returns>
    public static (Category Category, string error) Create(Guid id, string title, string description)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
        {
            error = "Title can not be empty or longer then 250 symbols";
        }

        var category = new Category(id, title, description);

        return (category, error);
    }
        
}