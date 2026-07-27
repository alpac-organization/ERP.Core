using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Shopping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class QuotedProductConfiguration : IEntityTypeConfiguration<QuotedProduct>
    {
        public void Configure(EntityTypeBuilder<QuotedProduct> builder)
        {
            builder.ToTable("quoted_products");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("quoted_product_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.IsWholesale)
                .HasColumnName("is_wholesale")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.PricePerUnit)
                .HasColumnName("price_per_unit")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.PriceWholesale)
                .HasColumnName("price_wholesale")
                .HasPrecision(18, 2);

            builder.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(e => e.EquivalentQuantity)
                .HasColumnName("equivalent_quantity");

            builder.Property(e => e.AdditionalData)
                .HasColumnName("additional_data")
                .HasColumnType("jsonb")
                .HasDefaultValue("{}");

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(e => e.UnitOfMeasureId)
                .HasColumnName("unit_measure_id")
                .IsRequired();

            builder.Property(e => e.QuoteDetailId)
                .HasColumnName("quote_detail_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.UnitMeasure)
                .WithMany()
                .HasForeignKey(e => e.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.QuoteDetail)
                .WithMany(z => z.QuotedProducts)
                .HasForeignKey(e => e.QuoteDetailId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}