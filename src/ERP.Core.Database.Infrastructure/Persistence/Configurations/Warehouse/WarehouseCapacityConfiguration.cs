using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehouseCapacityConfiguration : IEntityTypeConfiguration<WarehouseCapacity>
{
    public void Configure(EntityTypeBuilder<WarehouseCapacity> builder)
    {
        builder.ToTable("warehouse_capacities");

        builder.Property(wc => wc.HasSpaceBetweenWall)
            .HasColumnName("has_space_between_wall")
            .IsRequired();

        builder.Property(c => c.MinimumHeight)
            .HasColumnName("minimum_height")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(c => c.MaximumHeight)
            .HasColumnName("maximum_height")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.AvailableSpaceWithSpacingM3)
            .HasColumnName("available_space_with_spacing_m3")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.AvailableSpaceWithoutSpacingM3)
            .HasColumnName("available_space_without_spacing_m3")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.SpacingTop)
            .HasColumnName("spacing_top")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.SpacingBotton)
            .HasColumnName("spacing_bottom")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.SpacingRight)
            .HasColumnName("spacing_right")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.SpacingLeft)
            .HasColumnName("spacing_left")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.UnusedSpaceM2)
            .HasColumnName("unused_space_m2")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.UnasedSpaceM3)
            .HasColumnName("unused_space_m3")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(wc => wc.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.HasOne(wc => wc.Warehouse)
            .WithOne(w => w.WarehouseCapacity)
            .HasForeignKey<WarehouseCapacity>(wc => wc.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
