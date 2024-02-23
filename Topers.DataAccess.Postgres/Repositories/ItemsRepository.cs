using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Topers.Core.Abstractions;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Models;

namespace Topers.DataAccess.Postgres.Repositories;

public class ItemsRepository(ApplicationDbContext dbContext, IMapper mapper) : IItemsRepository
{
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> Create(Item item)
    {
        var itemEntity = new ItemEntity
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            CategoryId = item.CategoryId
        };

        await dbContext.Item.AddAsync(itemEntity);
        await dbContext.SaveChangesAsync();

        return itemEntity.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await dbContext.Item
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<List<Item>> Get()
    {
        var dbItems = await dbContext.Item
            .AsNoTracking()
            .OrderBy(c => c.Title)
            .ToListAsync();

        var items = dbItems
            .Select(c => Item.Create(c.Id, c.Title, c.Description, c.CategoryId).Item)
            .ToList();

        return items;
    }

    public async Task<Item> GetById(Guid id)
    {
        var dbItem = await dbContext.Item
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        
        return mapper.Map<Item>(dbItem);
    }

    public async Task<List<Item>> GetByCategoryId(Guid id)
    {
        var dbItems = await dbContext.Item
            .Where(c => c.CategoryId == id)
            .ToListAsync();

        var items = dbItems
            .Select(i => Item.Create(i.Id, i.Title, i.Description, i.CategoryId).Item)
            .ToList();

        return items;
    }

    public async Task<Guid> Update(Item item)
    {
        await dbContext.Item
            .Where(c => c.Id == item.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Title, item.Title)
                .SetProperty(c => c.Description, item.Description));

        return item.Id;
    }
}