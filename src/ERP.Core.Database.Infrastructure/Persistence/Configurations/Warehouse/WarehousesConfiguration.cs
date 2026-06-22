using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class Warehouse : IEntityTypeConfiguration<Warehouses>
{
    public void Configure(EntityTypeBuilder<Warehouses> builder)
    {
        builder.ToTable("Warehouses");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Id)
            .HasColumnName("warehouse_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.HasIndex(w => w.Id)
            .IsUnique()
            .HasDatabaseName("ix_warehuose_id");

        builder.Property(w => w.CreatedAt)
            .HasColumnName("created_at")
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

        builder.Property(w => w.TotalWeightCapacity)
            .HasColumnName("total_wight_capacity")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.HasIndex(w => w.Code)
            .HasFilter("\"IsActive\" = 1 AND \"DeletedAt\" IS NULL")
            .IsUnique()
            .HasDatabaseName("ix_warehouse_code");

        builder.HasQueryFilter(w => w.IsActive && w.DeletedAt == null);

        builder.HasOne(w => w.Branch)
            .WithMany()
            .HasForeignKey(w => w.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(w => w.CustomerType)
            .WithMany()
            .HasForeignKey(w => w.AllowedCustomerTypeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}