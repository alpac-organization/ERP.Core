using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("product_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasIndex(p => p.Id)
            .IsUnique()
            .HasDatabaseName("ix_product_id");

        builder.Property(p => p.Code)
            .HasColumnName("code")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(p => p.Code)
            .IsUnique()
            .HasDatabaseName("ux_products_code");

        builder.Property(p => p.ProductName)
            .HasColumnName("product_name")
            .IsRequired();

        builder.Property(p => p.Description)
            .IsRequired(false);

        builder.Property(p => p.CategoryId)
            .HasColumnName("category_id")
            .IsRequired();

        builder.Property(p => p.UnitMeasureId)
            .HasColumnName("unit_measure_id")
            .IsRequired();

        builder.Property(p => p.IsTaxExempt)
            .HasColumnName("is_tax_exempt")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(p => p.ProductUsageType)
            .HasColumnName("product_usage_type")
            .HasColumnType("product_usage_type_enum")
            .HasDefaultValueSql("'insumo'::product_usage_type_enum")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(p => p.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.UnitMeasure)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UnitMeasureId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.SupplierProducts)
            .WithOne(sp => sp.Product)
            .HasForeignKey(sp => sp.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.PurchaseOrderItems)
            .WithOne(poi => poi.Product)
            .HasForeignKey(poi => poi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
