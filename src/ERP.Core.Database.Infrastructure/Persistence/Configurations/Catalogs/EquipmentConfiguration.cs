using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.ToTable("equipments");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("equipment_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(e => e.BranchId)
            .HasColumnName("branch_id")
            .IsRequired();

        builder.Property(e => e.Code)
            .HasColumnName("code")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.SerialNumber)
            .HasColumnName("serial_number")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Brand)
            .HasColumnName("brand")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Model)
            .HasColumnName("model")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Year)
            .HasColumnName("year")
            .HasMaxLength(4)
            .IsRequired();

        builder.Property(e => e.Type)
            .HasColumnName("type")
            .HasColumnType("equipment_type_enum")
            .HasDefaultValueSql("'forklift'::equipment_type_enum")
            .IsRequired();

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("equipment_status_enum")
            .HasDefaultValueSql("'available'::equipment_status_enum")
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        builder.Property(e => e.Color)
            .HasColumnName("color")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(e => e.Gasoline)
            .HasColumnName("gasoline")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.Diesel)
            .HasColumnName("diesel")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.Electric)
            .HasColumnName("electric")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.Lpg)
            .HasColumnName("lpg")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasOne(e => e.Branch)
            .WithMany(b => b.Equipment)
            .HasForeignKey(e => e.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}