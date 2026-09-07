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

        // builder.Property(w => w.WarehouseType)
        //     .HasColumnName("warehouse_type")
        //     .HasColumnType("warehouse_type_enum")
        //     .HasDefaultValueSql("'fiscal'::warehouse_type_enum")
        //     .IsRequired(); 

        builder.Property(w => w.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(w => w.LocationId)
            .HasColumnName("location_id")
            .IsRequired(false);

        // ---- Relationships ----

        builder.HasOne(w => w.Location)
            .WithMany(l => l.Warehouses)
            .HasForeignKey(w => w.LocationId)
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