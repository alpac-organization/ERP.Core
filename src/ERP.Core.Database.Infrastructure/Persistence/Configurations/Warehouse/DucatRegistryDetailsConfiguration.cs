using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class DucatRegistryDetailsConfiguration : IEntityTypeConfiguration<DucatRegistryDetails>
{
    public void Configure(EntityTypeBuilder<DucatRegistryDetails> builder)
    {
        builder.ToTable("ducat_registry_details");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ducat_registry_detail_id")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();

        builder.Property(e => e.EntranceDucatId)
            .HasColumnName("entrance_ducat_id")
            .IsRequired();

        builder.Property(e => e.CategoryProductId)
            .HasColumnName("category_product_id")
            .IsRequired();
        
        builder.Property(e => e.TotalBultos)
            .HasColumnName("total_bultos")
            .IsRequired();

        builder.Property(e => e.TotalWeight)
            .HasColumnName("total_weight")
            .HasPrecision(18, 4)
            .IsRequired();
        
        builder.Property(e => e.ProductDescription)
            .HasColumnName("product_description")
            .HasMaxLength(500)
            .IsRequired();
       
        builder.Property(e => e.Remitente)
            .HasColumnName("remitente")
            .HasMaxLength(200)
            .IsRequired();
       
        builder.Property(e => e.DestinationAreaObservation)
            .HasColumnName("destination_area_observation")
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        // Relación N:1 con el Maestro de Oficina
        builder.HasOne(e => e.DucatRegistry)
            .WithMany(h => h.Details)
            .HasForeignKey(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.EntranceDucat)
            .WithOne(h => h.RegistryDetail)
            .HasForeignKey<DucatRegistryDetails>(e => e.EntranceDucatId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.CategoryProduct)
            .WithMany()
            .HasForeignKey(e => e.CategoryProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}