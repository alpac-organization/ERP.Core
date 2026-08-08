using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehouseCapacityConfiguration : IEntityTypeConfiguration<WarehouseCapacity>
{
    public void Configure(EntityTypeBuilder<WarehouseCapacity> builder)
    {
        builder.ToTable("warehouse_capacities");
        builder.HasKey(wc => wc.Id);

        builder.Property(wc => wc.Id)
            .HasColumnName("warehouse_capacity_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(wc => wc.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.Property(wc => wc.TotalAreaM2)
            .HasColumnName("total_area_m2")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(wc => wc.UsableAreaM2)
            .HasColumnName("usable_area_m2")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(wc => wc.UnusableAreaM2)
            .HasColumnName("unusable_area_m2")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(wc => wc.TotalMaxPolines)
            .HasColumnName("total_max_polines")
            .IsRequired();

        builder.Property(wc => wc.CurrentPolinesStored)
            .HasColumnName("current_polines_stored")
            .IsRequired();

        builder.Property(wc => wc.LastCalculatedAt)
            .HasColumnName("last_calculated_at")
            .IsRequired();

        builder.Property(wc => wc.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(wc => wc.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        builder.HasOne(wc => wc.Warehouse)
            .WithOne(w => w.Capacity)
            .HasForeignKey<WarehouseCapacity>(wc => wc.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(wc => wc.WarehouseId)
            .IsUnique()
            .HasDatabaseName("ix_warehouse_capacities_warehouse_id");
    }
}