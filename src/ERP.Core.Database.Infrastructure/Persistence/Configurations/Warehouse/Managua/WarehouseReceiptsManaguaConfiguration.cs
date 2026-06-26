using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class WarehouseReceiptsManaguaConfiguration : IEntityTypeConfiguration<WarehouseReceiptsManagua>
{
    public void Configure(EntityTypeBuilder<WarehouseReceiptsManagua> builder)
    {
        builder.ToTable("warehouse_receipts_managua");
        builder.HasKey(e => e.RecordEntranceManaguaId);
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_id")
            .ValueGeneratedNever();
        
        builder.Property(e => e.ReceiptNumber)
            .HasColumnName("receipt_number")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.HasIndex(e => e.ReceiptNumber)
          .IsUnique();
        
        builder.Property(e => e.ResaNumber)
            .HasColumnName("resa_number")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.CustomsCIFValue)
            .HasColumnName("customs_cif_value")
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(e => e.CustomsBrokerage)
            .HasColumnName("customs_brokerage")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.ReceiptCreationDate)
            .HasColumnName("receipt_creation_date")
            .IsRequired();
            
        builder.Property(e => e.ReceiptCancellationDate)
            .HasColumnName("receipt_cancellation_date");

        builder.HasOne(e => e.RecordEntranceManagua)
            .WithOne()
            .HasForeignKey<WarehouseReceiptsManagua>(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}