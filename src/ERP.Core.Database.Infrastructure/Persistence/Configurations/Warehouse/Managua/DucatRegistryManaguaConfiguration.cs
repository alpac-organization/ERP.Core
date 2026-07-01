using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class DucatRegistryManaguaConfiguration : IEntityTypeConfiguration<DucatRegistryManagua>
{
    public void Configure(EntityTypeBuilder<DucatRegistryManagua> builder)
    {
        builder.ToTable("ducat_registry_headers_managua");
        builder.HasKey(e => e.RecordEntranceManaguaId); 

        builder.Property(e => e.RecordEntranceManaguaId)
          .HasColumnName("record_entrance_id");
        
        builder.Property(e => e.RegistryDate)
            .HasColumnName("registry_date")
            .IsRequired();
        
        builder.Property(e => e.EntryTime)
            .HasColumnName("entry_time")
            .IsRequired();
            
        builder.Property(e => e.TrailerIdentifier)
            .HasColumnName("trailer_identifier")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.Empresa)
            .HasColumnName("empresa")
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(e => e.Transportista)
            .HasColumnName("transportista")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.Aduana)
            .HasColumnName("aduana")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.Consignee)
            .HasColumnName("consignee")
            .HasMaxLength(150)
            .IsRequired();

        // Relación 1:1 con la entrada principal
        builder.HasOne(e => e.RecordEntrance)
            .WithOne(r => r.DucatRegistry)
            .HasForeignKey<DucatRegistryManagua>(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}