using Topers.Core.Models;

namespace Topers.Core.Abstractions;

public interface ICategoriesService
{
    Task<Guid> CreateCategory(Category category);
    
    Task<Guid> DeleteCategory(Guid id);
    
    Task<List<Category>> GetAllCategories();

    Task<Category> GetCategoryById(Guid id);
    
    Task<Guid> UpdateCategory(Category category);
}