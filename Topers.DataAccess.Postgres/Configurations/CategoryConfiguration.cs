using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Topers.DataAccess.Postgres.Models;

namespace Topers.DataAccess.Postgres.Configurations;

/// <summary>
/// Represents a category configuration.
/// </summary>
public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasMany(i => i.Items)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId);

    }
}