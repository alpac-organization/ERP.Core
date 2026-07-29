using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class CustomsDeclarationConfiguration : IEntityTypeConfiguration<CustomsDeclarations>
{
    public void Configure(EntityTypeBuilder<CustomsDeclarations> builder)
    {
        builder.ToTable("customs_declarations");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("customs_declaration_id");
            
        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();

        builder.Property(e => e.CustomsDeclarationNumber)
            .HasColumnName("number")
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
 
        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");
        
        builder.HasOne(e => e.RecordEntrance)
            .WithOne(e => e.CustomsDeclarations)
            .HasForeignKey<CustomsDeclarations>(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}