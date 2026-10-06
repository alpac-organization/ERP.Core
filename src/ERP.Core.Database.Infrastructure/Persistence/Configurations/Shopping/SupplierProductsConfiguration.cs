using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class SupplierProductsConfiguration : IEntityTypeConfiguration<SupplierProduct>
    {
        public void Configure(EntityTypeBuilder<SupplierProduct> builder)
        {
            builder.ToTable("supplier_products");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("supplier_product_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.UnitPrice)
                .HasColumnName("unit_price")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.LastPriceUpdate)
                .HasColumnName("last_price_update")
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(e => e.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasIndex(e => new { e.SupplierId, e.ProductId })
                .IsUnique()
                .HasDatabaseName("ux_supplier_products_supplier_product");

            builder.HasIndex(e => e.ProductId)
                .HasDatabaseName("ix_supplier_products_product_id");

            builder.HasIndex(e => e.SupplierId)
                .HasDatabaseName("ix_supplier_products_supplier_id");

            builder.HasOne(e => e.Product)
                .WithMany(p => p.SupplierProducts)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Supplier)
                .WithMany(s => s.SupplierProducts)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.PriceHistories)
                .WithOne(h => h.SupplierProduct)
                .HasForeignKey(h => h.SupplierProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.TierPrices)
                .WithOne(t => t.SupplierProduct)
                .HasForeignKey(t => t.SupplierProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Quotations)
                .WithOne(q => q.SupplierProduct)
                .HasForeignKey(q => q.SupplierProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
