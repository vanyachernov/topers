using Microsoft.EntityFrameworkCore;
using Topers.DataAccess.Postgres.Configurations;
using Topers.DataAccess.Postgres.Models;

namespace Topers.DataAccess.Postgres;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options)
{
    
    public DbSet<CategoryEntity> Category { get; set; }
    
    public DbSet<ItemEntity> Item { get; set; }
    
    public DbSet<ItemDetails> ItemDetails { get; set; }
    
    public DbSet<OrderEntity> Order { get; set; }
    
    public DbSet<OrderDetailsEntity> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new ItemDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new OrderHeaderConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}