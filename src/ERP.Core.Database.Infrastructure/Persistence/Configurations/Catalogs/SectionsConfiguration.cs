using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class SectionsConfiguration : IEntityTypeConfiguration<Sections>
{
    public void Configure(EntityTypeBuilder<Sections> builder)
    {
        builder.ToTable("sections");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("section_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.Property(e => e.Code)
            .HasColumnName("code")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Name)
            .HasColumnName("section_name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(s => s.SectionType)
            .HasColumnName("section_type")
            .HasColumnType("section_type_enum")
            .HasDefaultValue(SectionType.Storage)
            .IsRequired();

        builder.Property(s => s.StorageType)
            .HasColumnName("storage_type")
            .HasColumnType("section_storage_type_enum")
            .HasDefaultValue(SectionStorageType.Empty)
            .IsRequired();

        builder.Property(e => e.WidthMetres)
            .HasColumnName("width_metres")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(e => e.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.Property(e => e.LengthMetres)
            .HasColumnName("length_metres")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasIndex(s => s.WarehouseId)
            .HasDatabaseName("ix_sections_warehouse_id");

        // Relación con el almacén inmutable central
        builder.HasOne(x => x.Warehouse)
            .WithMany(x => x.Sections)
            .HasForeignKey(x => x.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
