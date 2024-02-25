using Topers.DataAccess.Postgres.Repositories;
using Topers.Core.Abstractions;
using Topers.Core.Models;

namespace Topers.Application.Services;

public class CategoriesService(ICategoriesRepository categoryRepository) : ICategoriesService
{
    public async Task<List<Category>> GetAllCategories()
    {
        return await categoryRepository.Get();
    }

    public async Task<Category> GetCategoryById(Guid id)
    {
        return await categoryRepository.GetById(id);
    }

    public async Task<Guid> CreateCategory(Category category)
    {
        return await categoryRepository.Create(category);
    }

    public async Task<Guid> UpdateCategory(Category category)
    {
        return await categoryRepository.Update(category);
    }

    public async Task<Guid> DeleteCategory(Guid id)
    {
        return await categoryRepository.Delete(id);
    }
}