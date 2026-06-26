using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;
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
            .HasColumnName("racks_managua_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.ZoneId)
            .HasColumnName("zone_id")
            .IsRequired();

        builder.Property(e => e.Code)
            .HasColumnName("code")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.RowNumber)
            .HasColumnName("row_number")
            .IsRequired();
       
        builder.Property(e => e.LevelNumber)
            .HasColumnName("level_number")
            .IsRequired();
        
        builder.Property(e => e.CostPerPosition)
            .HasColumnName("cost_per_position")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(e => e.IsOccupied)
            .HasColumnName("is_occupied")
            .HasDefaultValue(false);

        // Relación 1:N con Zonas
        builder.HasOne(e => e.Zone)
            .WithMany(z => z.Racks)
            .HasForeignKey(e => e.ZoneId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}