using Topers.Core.Models;

namespace Topers.DataAccess.Postgres.Repositories;

public interface ICategoriesRepository
{
    Task<Guid> Create(Category category);
    
    Task<Guid> Delete(Guid id);
    
    Task<List<Category>> Get();

    Task<Category> GetById(Guid id);
    
    Task<Guid> Update(Category category);
}