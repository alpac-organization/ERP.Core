using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class SupplierProductTierPricesConfiguration : IEntityTypeConfiguration<SupplierProductTierPrice>
    {
        public void Configure(EntityTypeBuilder<SupplierProductTierPrice> builder)
        {
            builder.ToTable("supplier_product_tier_prices");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("supplier_product_tier_price_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.MinQuantity)
                .HasColumnName("min_quantity")
                .IsRequired();

            builder.Property(e => e.PreferentialPrice)
                .HasColumnName("preferential_price")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.ValidFrom)
                .HasColumnName("valid_from")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.ValidTo)
                .HasColumnName("valid_to")
                .HasColumnType("date")
                .IsRequired(false);

            builder.Property(e => e.SupplierProductId)
                .HasColumnName("supplier_product_id")
                .IsRequired();

            builder.Property(e => e.UnitMeasureId)
                .HasColumnName("unit_measure_id")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasIndex(e => e.SupplierProductId)
                .HasDatabaseName("ix_supplier_product_tier_prices_supplier_product_id");

            builder.HasIndex(e => new { e.SupplierProductId, e.MinQuantity })
                .HasDatabaseName("ix_supplier_product_tier_prices_supplier_product_min_qty");

            builder.HasOne(e => e.SupplierProduct)
                .WithMany(sp => sp.TierPrices)
                .HasForeignKey(e => e.SupplierProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.UnitMeasure)
                .WithMany()
                .HasForeignKey(e => e.UnitMeasureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
