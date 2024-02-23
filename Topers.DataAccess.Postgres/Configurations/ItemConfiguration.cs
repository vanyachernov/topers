using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Topers.DataAccess.Postgres.Models;

namespace Topers.DataAccess.Postgres.Configurations;

/// <summary>
/// Represents an item configuration.
/// </summary>
public class ItemConfiguration : IEntityTypeConfiguration<ItemEntity>
{
    public void Configure(EntityTypeBuilder<ItemEntity> builder)
    {
        builder.HasKey(i => i.Id);

        builder
            .HasOne(i => i.Category)
            .WithMany(c => c.Items)
            .HasForeignKey(i => i.CategoryId);

        builder
            .HasMany(i => i.Details)
            .WithOne(d => d.Item)
            .HasForeignKey(d => d.ItemId);
    }
}