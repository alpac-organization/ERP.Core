using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class OutsourcedWarehousesConfigurations : IEntityTypeConfiguration<OutsourcedWarehouse>
{
    public void Configure(EntityTypeBuilder<OutsourcedWarehouse> builder)
    {
        builder.ToTable("outsourced_warehouses");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Id)
            .HasColumnName("outsourced_warehouse_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasIndex(w => w.Id)
            .IsUnique()
            .HasDatabaseName("ix_outsourced_warehouse_id");

        builder.Property(w => w.Code)
            .HasColumnName("code")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(w => w.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(w => w.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(w => w.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);
    }
}