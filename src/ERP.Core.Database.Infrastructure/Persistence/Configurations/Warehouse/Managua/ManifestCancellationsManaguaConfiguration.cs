using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class ManifestCancellationsManaguaConfiguration : IEntityTypeConfiguration<ManifestCancellationsManagua>
{
    public void Configure(EntityTypeBuilder<ManifestCancellationsManagua> builder)
    {
        builder.ToTable("manifest_cancellations_managua");
        builder.HasKey(e => e.RecordEntranceManaguaId);
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_id")
            .ValueGeneratedNever();
        
        builder.Property(e => e.ManifestNumber)
            .HasColumnName("manifest_number")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.ContainerCount)
            .HasColumnName("container_count")
            .IsRequired();
        
        builder.Property(e => e.ContainerDimension)
            .HasColumnName("container_dimension")
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(e => e.PersonnelType)
            .HasColumnName("personnel_type")
            .HasMaxLength(50)
            .IsRequired();
            
        builder.Property(e => e.CustomsOfficerSignature)
            .HasColumnName("customs_officer_signature")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.WarehouseChiefSignature)
            .HasColumnName("warehouse_chief_signature")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(e => e.RecordEntranceManagua)
            .WithOne()
            .HasForeignKey<ManifestCancellationsManagua>(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}