using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class Warehouse : IEntityTypeConfiguration<Warehouses>
{
    public void Configure(EntityTypeBuilder<Warehouses> builder)
    {
        builder.ToTable("warehouses");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Id)
            .HasColumnName("warehouse_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.HasIndex(w => w.Id)
            .IsUnique()
            .HasDatabaseName("ix_warehouse_id");

        builder.Property(w => w.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(w => w.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        builder.Property(w => w.Code)
            .HasColumnName("code")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(w => w.Name)
            .HasColumnName("warehouse_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.TotalCubicCapacity)
            .HasColumnName("total_cubic_capacity")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(w => w.IsOwner)
            .HasColumnName("is_owner")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(w => w.WarehouseType)
            .HasColumnName("warehouse_type")
            .HasConversion<int>()
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
            .HasPrecision(5, 1)
            .IsRequired();

        builder.Property(w => w.ParkingSpacesCount)
            .HasColumnName("parking_spaces_count")
            .HasPrecision(5, 1)
            .IsRequired();

        builder.Property(w => w.ParentWarehouseId)
            .HasColumnName("parent_warehouse_id");

        builder.Property(w => w.BranchId)
            .HasColumnName("branch_id")
            .IsRequired();

        builder.HasOne(w => w.Branch)
            .WithMany(e => e.Warehouses)
            .HasForeignKey(w => w.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(w => w.ParentWarehouse)
            .WithMany(w => w.SubWarehouses)
            .HasForeignKey(w => w.ParentWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}