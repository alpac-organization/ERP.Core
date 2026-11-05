using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory;

public class FuelRequestConfiguration : IEntityTypeConfiguration<FuelRequest>
{
    public void Configure(EntityTypeBuilder<FuelRequest> builder)
    {
        builder.ToTable("fuel_requests");

        builder.Property(fr => fr.MachineryId)
            .HasColumnName("machinery_id")
            .IsRequired();

        builder.Property(fr => fr.ProductStockId)
            .HasColumnName("product_stock_id")
            .IsRequired();

        builder.Property(fr => fr.UnitMeasureId)
            .HasColumnName("unit_measure_id")
            .IsRequired();

        builder.Property(fr => fr.RequestedQuantity)
            .HasColumnName("requested_quantity")
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(fr => fr.Mileage)
            .HasColumnName("mileage")
            .HasPrecision(10, 2)
            .IsRequired(false);

        builder.Property(fr => fr.EngineHours)
            .HasColumnName("engine_hours")
            .HasPrecision(9, 2)
            .IsRequired(false);

        #region Foreign Keys

        builder.HasOne(fr => fr.Machinery)
            .WithMany()
            .HasForeignKey(fr => fr.MachineryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(fr => fr.ProductStock)
            .WithMany()
            .HasForeignKey(fr => fr.ProductStockId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(fr => fr.UnitMeasure)
            .WithMany()
            .HasForeignKey(fr => fr.UnitMeasureId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion Foreign Keys
    }
}