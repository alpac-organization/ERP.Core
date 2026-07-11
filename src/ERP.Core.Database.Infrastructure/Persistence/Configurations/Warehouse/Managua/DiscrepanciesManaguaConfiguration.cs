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
        
        builder.HasIndex(e => e.Id)
            .IsUnique()
            .HasDatabaseName("ix_discrepancy_id");
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_id")
            .IsRequired();

        builder.Property(e => e.IsDamage)
            .HasColumnName("is_damage")
            .IsRequired();
        
        builder.Property(e => e.EntranceDucatsManaguaId)
            .HasColumnName("entrance_ducats_id")
            .IsRequired();
        
        builder.Property(e => e.DiscrepancyType)
            .HasColumnName("discrepancy_type")
            .HasMaxLength(50).IsRequired();
        
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
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(e => e.IsDamage)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.RecordEntranceManagua)
            .WithMany()
            .HasForeignKey(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.EntranceDucat)
            .WithMany()
            .HasForeignKey(e => e.EntranceDucatsManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}