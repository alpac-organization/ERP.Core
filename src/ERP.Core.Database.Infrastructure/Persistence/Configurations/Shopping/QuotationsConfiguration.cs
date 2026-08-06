using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class QuotationsConfiguration : IEntityTypeConfiguration<Quotation>
    {
        public void Configure(EntityTypeBuilder<Quotation> builder)
        {
            builder.ToTable("quotations");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("quotation_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.HasDelivery)
                .HasColumnName("has_delivery")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.HasGuarantee)
                .HasColumnName("has_guarantee")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.Iva)
                .HasColumnName("iva")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.Price)
                .HasColumnName("price")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.PriceUnit)
                .HasColumnName("price_unit")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.PriceTotal)
                .HasColumnName("price_total")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.QuoteDate)
                .HasColumnName("quote_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.BrandProduct)
                .HasColumnName("brand_product")
                .HasMaxLength(255);

            builder.Property(e => e.DeliveryTime)
                .HasColumnName("delivery_time")
                .HasPrecision(18, 2)
                .IsRequired(false);

            builder.Property(e => e.DeliveryTimeType)
                .HasColumnName("delivery_time_type")
                .HasColumnType("time_type_enum")
                .IsRequired(false);

            builder.Property(e => e.WarrantyPeriod)
                .HasColumnName("warranty_period")
                .HasPrecision(18, 2)
                .IsRequired(false);

            builder.Property(e => e.WarrantyPeriodTimeType)
                .HasColumnName("warranty_period_time_type")
                .HasColumnType("time_type_enum")
                .IsRequired(false);

            builder.Property(e => e.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired();

            builder.Property(e => e.PurchaseRequestId)
                .HasColumnName("purchase_request_id")
                .IsRequired();

            builder.HasOne(e => e.Supplier)
                .WithMany(s => s.Quotations)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PurchaseRequestItem)
                .WithMany(pri => pri.Quotations)
                .HasForeignKey(e => e.PurchaseRequestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}