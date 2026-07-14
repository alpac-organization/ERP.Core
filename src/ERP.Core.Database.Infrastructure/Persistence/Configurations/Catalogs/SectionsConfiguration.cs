using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ERP.Core.Database.Domain.Entities.Catalogs;

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

        builder.Property(e => e.HeightMetres)
            .HasColumnName("heigth_metres")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(e => e.TotalVolumeCapacityM3)
            .HasColumnName("total_colume_capacity_m3")
            .HasPrecision(12, 3)
            .IsRequired();

        builder.Property(e => e.MaxWeightCapacityKg)
            .HasColumnName("max_weight_capacity_kg")
            .HasPrecision(14, 2)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        // Relación con el almacén inmutable central
        builder.HasOne(x => x.Warehouses)
            .WithMany(x => x.Sections)
            .HasForeignKey(x => x.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
