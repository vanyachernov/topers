using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Models;

namespace Topers.DataAccess.Postgres.Repositories;

public class CategoriesRepository(ApplicationDbContext dbContext, IMapper mapper) : ICategoriesRepository
{
    public async Task<List<Category>> Get()
    {
        var dbCategories = await dbContext.Category
            .AsNoTracking()
            .OrderBy(c => c.Title)
            .ToListAsync();

        var categories = dbCategories
            .Select(c => Category.Create(c.Id, c.Title, c.Description).Category)
            .ToList();

        return categories;
    }
    
    public async Task<Category> GetById(Guid id)
    {
        var dbCategory = await dbContext.Category
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        
        return mapper.Map<Category>(dbCategory);
    }

    public async Task<Guid> Create(Category category)
    {
        var categoryEntity = new CategoryEntity
        {
            Id = category.Id,
            Title = category.Title,
            Description = category.Description
        };

        await dbContext.Category.AddAsync(categoryEntity);
        await dbContext.SaveChangesAsync();

        return categoryEntity.Id;
    }

    public async Task<Guid> Update(Category category)
    {
        await dbContext.Category
            .Where(c => c.Id == category.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Title, category.Title)
                .SetProperty(c => c.Description, category.Description));

        return category.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await dbContext.Category
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}