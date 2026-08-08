using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Enums;

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

        builder.HasIndex(w => w.Code)
            .IsUnique()
            .HasDatabaseName("ix_warehouses_code");

        builder.Property(w => w.WarehouseName)
            .HasColumnName("warehouse_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(w => w.WarehouseType)
            .HasColumnName("warehouse_type")
            .HasColumnType("warehouse_type_enum")
            .HasDefaultValue(WarehouseType.Fiscal)
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
        
        builder.HasIndex(w => w.BranchId)
            .HasDatabaseName("ix_warehouses_branch_id");

        builder.HasOne(w => w.ParentWarehouse)
            .WithMany(w => w.SubWarehouses)
            .HasForeignKey(w => w.ParentWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(w => w.ParentWarehouseId)
            .HasDatabaseName("ix_warehouses_parent_wareouse_id");
    }
}