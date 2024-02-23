using Topers.Core.Models;

namespace Topers.Core.Abstractions;

public interface IItemsService
{
    Task<Guid> CreateItem(Item item);
    
    Task<List<Item>> GetAllItems();
    
    Task<Item> GetItemById(Guid id);

    Task<List<Item>> GetItemsByCategoryId(Guid id);
    
    Task<Guid> UpdateItem(Item item);
    
    Task<Guid> DeleteItem(Guid id);
}