using Topers.Core.Models;

namespace Topers.Core.Abstractions;

public interface IItemsRepository
{
    Task<Guid> Create(Item item);
    
    Task<Guid> Delete(Guid id);
    
    Task<List<Item>> Get();

    Task<Item> GetById(Guid id);

    Task<List<Item>> GetByCategoryId(Guid id);
    
    Task<Guid> Update(Item item);
}