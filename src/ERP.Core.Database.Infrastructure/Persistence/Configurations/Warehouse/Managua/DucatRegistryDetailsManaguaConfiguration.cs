using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class DucatRegistryDetailsManaguaConfiguration : IEntityTypeConfiguration<DucatRegistryDetailsManagua>
{
    public void Configure(EntityTypeBuilder<DucatRegistryDetailsManagua> builder)
    {
        builder.ToTable("ducat_registry_details_managua");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ducat_registry_detail_id")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_id")
            .IsRequired();

        builder.Property(e => e.DucatNumber)
            .HasColumnName("ducat_number")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.PackageCount)
            .HasColumnName("package_count")
            .IsRequired();
        
        builder.Property(e => e.TotalWeight)
            .HasColumnName("total_weight")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(e => e.ProductDescription)
            .HasColumnName("product_description")
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(e => e.SenderName)
            .HasColumnName("sender_name")
            .HasMaxLength(150)
            .IsRequired();
       
        builder.Property(e => e.DestinationAreaObservation)
            .HasColumnName("destination_area_observation")
            .HasMaxLength(250)
            .IsRequired();

        // Relación N:1 con el Maestro de Oficina
        builder.HasOne(e => e.DucatRegistry)
            .WithMany(h => h.Details)
            .HasForeignKey(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}