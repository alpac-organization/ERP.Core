using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehouseCapacityConfiguration : IEntityTypeConfiguration<WarehouseCapacity>
{
    public void Configure(EntityTypeBuilder<WarehouseCapacity> builder)
    {
        builder.ToTable("warehouse_capacities");

        builder.Property(wc => wc.HasMargins)
            .HasColumnName("has_margins")
            .IsRequired();

        builder.Property(c => c.MinimumHeight)
            .HasColumnName("minimum_height")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(c => c.MaximumHeight)
            .HasColumnName("maximum_height")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.MarginTop)
            .HasColumnName("margin_top")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.MarginBottom)
            .HasColumnName("margin_bottom")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.MarginRight)
            .HasColumnName("margin_right")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.MarginLeft)
            .HasColumnName("margin_left")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.UnusedVolumenM3)
            .HasColumnName("unused_volumen_m3")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.AvailableVolumenWithMarginM3)
            .HasColumnName("available_volumen_with_margin_m3")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.TotalVolumenM3)
            .HasColumnName("total_volumen_m3")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.UnoccupiedChargeableVolumenM3)
            .HasColumnName("unoccupied_chargeable_volumen_m3")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.OccupiedChargeableVolumenM3)
            .HasColumnName("occupied_chargeable_volumen_m3")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.PercentageAvailableVolumenWithMarginM3)
            .HasColumnName("percentage_available_volumen_with_margin_m3")
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(wc => wc.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.HasOne(wc => wc.Warehouse)
            .WithOne(w => w.WarehouseCapacity)
            .HasForeignKey<WarehouseCapacity>(wc => wc.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
