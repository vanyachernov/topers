using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Topers.DataAccess.Postgres.Models;

namespace Topers.DataAccess.Postgres.Configurations;

/// <summary>
/// Represents an item details configuration.
/// </summary>
public class ItemDetailsConfiguration : IEntityTypeConfiguration<ItemDetails>
{
    public void Configure(EntityTypeBuilder<ItemDetails> builder)
    {
        builder.HasKey(d => d.Id);

        builder
            .HasOne(d => d.Item)
            .WithMany(i => i.Details)
            .HasForeignKey(i => i.ItemId);
    }
}