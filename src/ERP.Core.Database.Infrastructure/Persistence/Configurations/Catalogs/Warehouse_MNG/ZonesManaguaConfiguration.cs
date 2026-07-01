using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs.Warehouse_MNG;

public class ZonesManaguaConfiguration : IEntityTypeConfiguration<ZonesManagua>
{
    public void Configure(EntityTypeBuilder<ZonesManagua> builder)
    {
        builder.ToTable("zones_managua");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("zones_managua_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.Property(e => e.Code)
            .HasColumnName("code")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.Name)
            .HasColumnName("zone_name")
            .HasMaxLength(100)
            .IsRequired();

        // Relación con tabla maestra de Bodegas
        builder.HasOne(e => e.Warehouses)
            .WithMany() 
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.WarehouseId, e.Code }).IsUnique();
    }
}
