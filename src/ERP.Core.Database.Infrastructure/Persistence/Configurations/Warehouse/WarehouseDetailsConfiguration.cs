using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehouseDetailsConfiguration : IEntityTypeConfiguration<WarehouseDetails>
{
    public void Configure(EntityTypeBuilder<WarehouseDetails> builder)
    {
        builder.ToTable("warehouse_details");
        builder.HasKey(wd => wd.Id);

        builder.Property(wd => wd.Id)
            .HasColumnName("warehouse_details_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.HasIndex(w => w.Id)
            .IsUnique()
            .HasDatabaseName("ix_warehouse_details_id");

        builder.Property(w => w.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();
        
        builder.Property(w => w.TotalCubicCapacity)
            .HasColumnName("total_cubic_capacity")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.TotalArea)
            .HasColumnName("total_area")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.NetStorageArea)
            .HasColumnName("net_storage_area")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.UnusableArea)
            .HasColumnName("unusable_area")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.MaxHeight)
            .HasColumnName("max_height")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.MinHeight)
            .HasColumnName("min_height")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.RampasCount)
            .HasColumnName("rampas_count")
            .IsRequired();

        builder.Property(w => w.ParkingSpacesCount)
            .HasColumnName("parking_spaces_count")
            .IsRequired();

        builder.Property(w => w.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(w => w.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        builder.HasOne(wd => wd.Warehouses)
            .WithOne(w => w.WarehouseDetails)
            .HasForeignKey<WarehouseDetails>(wd => wd.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}