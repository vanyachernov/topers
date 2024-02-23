using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Topers.DataAccess.Postgres.Models;

namespace Topers.DataAccess.Postgres.Configurations;

/// <summary>
/// Represents an order details configuration.
/// </summary>
public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetailsEntity>
{
    public void Configure(EntityTypeBuilder<OrderDetailsEntity> builder)
    {
        builder.HasKey(d => d.Id);

        builder
            .HasOne(d => d.Order)
            .WithMany(o => o.Details)
            .HasForeignKey(d => d.OrderId);
    }
}