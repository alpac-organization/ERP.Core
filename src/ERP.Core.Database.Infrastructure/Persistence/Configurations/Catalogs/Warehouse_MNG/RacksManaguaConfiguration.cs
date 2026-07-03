using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs.Warehouse_MNG;

public class RacksManaguaConfiguration : IEntityTypeConfiguration<RacksManagua>
{
    public void Configure(EntityTypeBuilder<RacksManagua> builder)
    {
        builder.ToTable("racks_managua");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("racks_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.ZoneId)
            .HasColumnName("zone_id")
            .IsRequired();

        builder.Property(e => e.Code)
            .HasColumnName("code")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.RowNumber)
            .HasColumnName("row_number")
            .IsRequired();
       
        builder.Property(e => e.LevelNumber)
            .HasColumnName("level_number")
            .IsRequired();
        
        builder.Property(e => e.CostPerPosition)
            .HasColumnName("cost_per_position")
            .HasPrecision(12, 4)
            .IsRequired();

        builder.Property(e => e.IsAvailable)
            .HasColumnName("is_available")
            .HasDefaultValue(true);
        
        builder.Property(e => e.MaxWeightKg)
            .HasColumnName("max_weight_kg")
            .HasPrecision(12, 2)
            .IsRequired();
        
        builder.Property(e => e.MaxHeightMetres)
            .HasColumnName("max_height_metres")
            .HasPrecision(10, 2)
            .IsRequired();

        // Relación 1:N con Zonas
        builder.HasOne(e => e.Zone)
            .WithMany(z => z.Racks)
            .HasForeignKey(e => e.ZoneId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}