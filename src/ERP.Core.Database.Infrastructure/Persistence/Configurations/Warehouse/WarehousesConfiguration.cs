using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehousesConfiguration : IEntityTypeConfiguration<Warehouses>
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

        builder.Property(w => w.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(w => w.LocationId)
            .HasColumnName("location_id")
            .IsRequired();

        builder.Property(w => w.CapacityId)
            .HasColumnName("capacity_id")
            .IsRequired();

        // ---- Relationships ----
        builder.HasOne(w => w.CapacityDetails)
            .WithOne(c => c.Warehouse)
            .HasForeignKey<Warehouses>(w => w.CapacityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(w => w.Location)
            .WithOne(l => l.Warehouse)
            .HasForeignKey<Warehouses>(w => w.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(w => w.Sections)
            .WithOne(s => s.Warehouse)
            .HasForeignKey(s => s.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(w => w.Code)
            .IsUnique()
            .HasDatabaseName("ix_warehouses_code");
    }
}