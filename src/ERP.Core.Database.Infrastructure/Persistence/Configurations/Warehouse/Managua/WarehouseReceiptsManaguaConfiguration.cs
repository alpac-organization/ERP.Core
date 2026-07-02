using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class WarehouseReceiptsManaguaConfiguration : IEntityTypeConfiguration<WarehouseReceiptsManagua>
{
    public void Configure(EntityTypeBuilder<WarehouseReceiptsManagua> builder)
    {
        builder.ToTable("warehouse_receipts_managua");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_managua_id")
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


        builder.HasOne(e => e.RecordEntranceManagua)
            .WithOne(e => e.WarehouseReceipt)
            .HasForeignKey<WarehouseReceiptsManagua>(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}