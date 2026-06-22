using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class CatalogWarehouseConfiguration : IEntityTypeConfiguration<CatalogWarehouse>
{
    public void Configure(EntityTypeBuilder<CatalogWarehouse> builder)
    {
        builder.ToTable("catalog_warehouse");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("catalog_warehouse_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Code)
            .HasColumnName("code")
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(c => c.ParentId)
            .HasColumnName("parent_id")
            .IsRequired(false);

        /// ========================================================
        /// Configuracion de la relacion recursiva 1 - N
        /// ========================================================
        builder.HasOne(c => c.Parent)
            .WithMany(p => p.Children)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    } 
}