using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class ManifestCancellationsConfiguration : IEntityTypeConfiguration<ManifestCancellations>
{
    public void Configure(EntityTypeBuilder<ManifestCancellations> builder)
    {
        builder.ToTable("manifest_cancellations");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("manifest_cancellation_id")
            .IsRequired();
        
        builder.Property(e => e.ServiceOrdersId)
            .HasColumnName("service_orders_id")
            .IsRequired();
        
        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();
        
        builder.Property(e => e.ManifestNumber)
            .HasColumnName("manifest_number")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.ContainerCount)
            .HasColumnName("container_count")
            .IsRequired();
        
        builder.Property(e => e.ContainerDimension)
            .HasColumnName("container_dimension")
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

        builder.HasOne(e => e.RecordEntrance)
            .WithOne(e => e.ManifestCancellation)
            .HasForeignKey<ManifestCancellations>(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ServiceOrder)
            .WithMany()
            .HasForeignKey(e => e.ServiceOrdersId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}