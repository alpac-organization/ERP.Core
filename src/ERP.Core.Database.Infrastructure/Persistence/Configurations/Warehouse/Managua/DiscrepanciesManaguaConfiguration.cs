using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class DiscrepanciesManaguaConfiguration : IEntityTypeConfiguration<DiscrepanciesManagua>
{
    public void Configure(EntityTypeBuilder<DiscrepanciesManagua> builder)
    {
        builder.ToTable("discrepancies_managua");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("discrepancy_id")
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_id")
            .IsRequired();
        
        builder.Property(e => e.ProductId)
            .HasColumnName("product_id")
            .IsRequired();
        
        builder.Property(e => e.DiscrepancyType)
            .HasColumnName("discrepancy_type")
            .HasMaxLength(30).IsRequired();
        
        builder.Property(e => e.DeclaredQuantity)
            .HasColumnName("declared_quantity")
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(e => e.FoundQuantity)
            .HasColumnName("found_quantity")
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(e => e.CustomsLetterReference)
            .HasColumnName("customs_letter_reference")
            .HasMaxLength(100);
        
        builder.Property(e => e.Description)
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired();

        builder.HasOne(e => e.RecordEntranceManagua)
            .WithMany()
            .HasForeignKey(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}