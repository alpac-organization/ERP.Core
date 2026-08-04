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

            builder.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(e => e.QuantityPerUnit)
                .HasColumnName("quantity_per_unit")
                .IsRequired(false);

            builder.Property(e => e.AdditionalData)
                .HasColumnName("additional_data")
                .HasColumnType("jsonb")
                .HasDefaultValue("{}");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(e => e.UnitMeasureId)
                .HasColumnName("unit_measure_id")
                .IsRequired();

            builder.Property(e => e.QuotationId)
                .HasColumnName("quotation_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.Quotation)
                .WithMany(e => e.QuotedProducts)
                .HasForeignKey(e => e.QuotationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Product)
                .WithMany(e => e.QuotedProducts)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.UnitOfMeasure)
                .WithMany(e => e.QuotedProducts)
                .HasForeignKey(e => e.UnitMeasureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}