using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class ManifestCancellationsManaguaConfiguration : IEntityTypeConfiguration<ManifestCancellationsManagua>
{
    public void Configure(EntityTypeBuilder<ManifestCancellationsManagua> builder)
    {
        builder.ToTable("manifest_cancellations_managua");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("manifest_cancellation_id")
            .IsRequired();
        
        builder.Property(e => e.ServiceOrdersId)
            .HasColumnName("service_orders_id")
            .IsRequired();
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_managua_id")
            .IsRequired();
        
        builder.Property(e => e.ManifestNumber)
            .HasColumnName("manifest_number")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.ContainerCount)
            .HasColumnName("container_count")
            .IsRequired();
            
        builder.Property(e => e.PersonalType)
            .HasColumnName("personal_type")
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(e => e.CustomsOfficerSignature)
            .HasColumnName("customs_officer_signature")
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(e => e.WarehouseChiefSignature)
            .HasColumnName("warehouse_chief_signature")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.RecordEntranceManagua)
            .WithOne(e => e.ManifestCancellation)
            .HasForeignKey<ManifestCancellationsManagua>(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ServiceOrder)
            .WithMany()
            .HasForeignKey(e => e.ServiceOrdersId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}