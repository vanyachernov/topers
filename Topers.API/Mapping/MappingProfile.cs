using AutoMapper;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Models;

namespace Topers.DataAccess.Postgres.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<CategoryEntity, Category>();
        this.CreateMap<ItemEntity, Item>();
        this.CreateMap<Category, CategoryEntity>();
        this.CreateMap<Item, ItemEntity>();
    }
}