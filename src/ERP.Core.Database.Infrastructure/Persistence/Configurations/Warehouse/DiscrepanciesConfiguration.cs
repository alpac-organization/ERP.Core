using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class DiscrepanciesConfiguration : IEntityTypeConfiguration<Discrepancies>
{
    public void Configure(EntityTypeBuilder<Discrepancies> builder)
    {
        builder.ToTable("discrepancies");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("discrepancy_id")
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.HasIndex(e => e.Id)
            .IsUnique()
            .HasDatabaseName("ix_discrepancy_id");
        
        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();

        builder.Property(e => e.IsDamage)
            .HasColumnName("is_damage")
            .IsRequired();
        
        builder.Property(e => e.EntranceDucatsId)
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

        builder.HasOne(e => e.RecordEntrance)
            .WithMany()
            .HasForeignKey(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.EntranceDucat)
            .WithMany()
            .HasForeignKey(e => e.EntranceDucatsId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}