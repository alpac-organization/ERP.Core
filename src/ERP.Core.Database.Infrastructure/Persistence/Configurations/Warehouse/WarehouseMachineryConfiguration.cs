using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehouseMachineryConfiguration : IEntityTypeConfiguration<WarehouseMachinery>
{
    public void Configure(EntityTypeBuilder<WarehouseMachinery> builder)
    {
        builder.ToTable("machinery_catalogs");
        builder.HasKey(w => w.Id);

        builder.Property(w => w.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(w => w.CompanyId)
            .HasColumnName("company_id")
            .IsRequired();

        builder.Property(w => w.BranchId)
            .HasColumnName("branch_id")
            .IsRequired();

        builder.Property(w => w.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.Property(w => w.AssignedOperatorId)
            .HasColumnName("assigned_operator_id")
            .IsRequired(false);

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
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(w => new { w.Code, w.CompanyId })
            .IsUnique();

        builder.Property(w => w.SerialNumber)
            .HasColumnName("serial_number")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.LicensePlate)
            .HasColumnName("license_plate")
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(w => w.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.Brand)
            .HasColumnName("brand")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.Model)
            .HasColumnName("model")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.ManufactureYear)
            .HasColumnName("manufacture_year")
            .IsRequired();

        builder.Property(w => w.ImageUrl)
            .HasColumnName("image_url")
            .IsRequired(false);

        builder.Property(w => w.MachineryType)
            .HasColumnName("machinery_type")
            .HasColumnType("machinery_type_enum")
            .IsRequired();

        builder.Property(w => w.FuelType)
            .HasColumnName("fuel_type")
            .IsRequired();

        builder.Property(w => w.LoadCapacityKg)
            .HasColumnName("load_capacity_kg")
            .IsRequired();

        builder.Property(w => w.MaxReachHeightMeters)
            .HasColumnName("max_reach_height_meters")
            .IsRequired(false);

        builder.Property(w => w.HourMeter)
            .HasColumnName("hour_meter")
            .IsRequired();

        builder.Property(w => w.Status)
            .HasColumnName("status")
            .IsRequired();

        builder.Property(w => w.LastMaintenanceDate)
            .HasColumnName("last_maintenance_date")
            .IsRequired(false);

        builder.Property(w => w.NextMaintenanceDate)
            .HasColumnName("next_maintenance_date")
            .IsRequired(false);

        builder.Property(w => w.Notes)
            .HasColumnName("notes")
            .IsRequired(false);

        builder.Property(w => w.PurchaseDate)
            .HasColumnName("purchase_date")
            .IsRequired(false);

        builder.Property(w => w.WarrantyExpirationDate)
            .HasColumnName("warranty_expiration_date")
            .IsRequired(false);

        builder.Property(w => w.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();
    }
}