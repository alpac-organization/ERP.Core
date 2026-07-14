using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehouseReceiptsConfiguration : IEntityTypeConfiguration<WarehouseReceipts>
{
    public void Configure(EntityTypeBuilder<WarehouseReceipts> builder)
    {
        builder.ToTable("warehouse_receipts");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();
        
        builder.Property(e => e.ReceiptNumber)
            .HasColumnName("receipt_number")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasIndex(e => e.ReceiptNumber)
          .IsUnique();
        
        builder.Property(e => e.ResaNumber)
            .HasColumnName("resa_number")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.CustomsCIFValue)
            .HasColumnName("customs_cif_value")
            .HasPrecision(18, 4)
            .IsRequired();
        
        builder.Property(e => e.CustomsBrokerage)
            .HasColumnName("customs_brokerage")
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(e => e.ReceiptCreationDate)
            .HasColumnName("receipt_creation_date")
            .IsRequired();
            
        builder.Property(e => e.ReceiptCancellationDate)
            .HasColumnName("receipt_cancellation_date");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");


        builder.HasOne(e => e.RecordEntrance)
            .WithOne(e => e.WarehouseReceipt)
            .HasForeignKey<WarehouseReceipts>(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}