using Topers.Core.Abstractions;
using Topers.Core.Models;

namespace Topers.Application.Services;

public class ItemService(IItemsRepository itemsRepository) : IItemsService
{
    public async Task<Guid> CreateItem(Item item)
    {
        return await itemsRepository.Create(item);
    }

    public async Task<List<Item>> GetAllItems()
    {
        return await itemsRepository.Get();
    }

    public async Task<Item> GetItemById(Guid id)
    {
        return await itemsRepository.GetById(id);
    }

    public async Task<List<Item>> GetItemsByCategoryId(Guid id)
    {
        return await itemsRepository.GetByCategoryId(id);
    }

    public async Task<Guid> UpdateItem(Item item)
    {
        return await itemsRepository.Update(item);
    }

    public async Task<Guid> DeleteItem(Guid id)
    {
        return await itemsRepository.Delete(id);
    }
}