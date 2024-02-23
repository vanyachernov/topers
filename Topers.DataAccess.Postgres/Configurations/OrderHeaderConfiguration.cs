using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Topers.DataAccess.Postgres.Models;

namespace Topers.DataAccess.Postgres.Configurations;

/// <summary>
/// Represents an order configuration.
/// </summary>
public class OrderHeaderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .HasMany(o => o.Details)
            .WithOne(d => d.Order)
            .HasForeignKey(d => d.OrderId);
    }
}