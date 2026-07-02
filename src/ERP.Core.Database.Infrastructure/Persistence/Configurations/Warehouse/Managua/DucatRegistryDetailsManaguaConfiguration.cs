using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class DucatRegistryDetailsManaguaConfiguration : IEntityTypeConfiguration<DucatRegistryDetailsManagua>
{
    public void Configure(EntityTypeBuilder<DucatRegistryDetailsManagua> builder)
    {
        builder.ToTable("ducat_registry_details_managua");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ducat_registry_detail_id")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_id")
            .IsRequired();

        builder.Property(e => e.EntranceDucatManaguaId)
            .HasColumnName("entrance_ducat_managua_id")
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
            .HasForeignKey(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.EntranceDucat)
            .WithOne(h => h.RegistryDetail)
            .HasForeignKey<DucatRegistryDetailsManagua>(e => e.EntranceDucatManaguaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.CategoryProduct)
            .WithMany()
            .HasForeignKey(e => e.CategoryProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}