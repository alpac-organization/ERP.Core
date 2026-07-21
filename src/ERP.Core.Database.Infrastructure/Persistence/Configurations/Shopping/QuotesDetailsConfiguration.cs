using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class QuotesDetailsConfiguration : IEntityTypeConfiguration<QuoteDetail>
    {
        public void Configure(EntityTypeBuilder<QuoteDetail> builder)
        {
            builder.ToTable("quotes_details");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("quote_detail_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Observations)
                .HasColumnName("observations")
                .IsRequired(false);
 
            builder.Property(e => e.Amount)
                .HasColumnName("amount")
                .IsRequired(true);

            builder.Property(e => e.Color)
                .HasColumnName("color")
                .IsRequired(false);

            builder.Property(e => e.IndividualPrice)
                .HasColumnName("individual_price")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.AdditionalData)
                .HasColumnName("additional_data")
                .HasColumnType("jsonb")
                .IsRequired();

            builder.Property(e => e.QuotationId)
                .HasColumnName("quotation_id")
                .IsRequired();

            builder.Property(e => e.UnitMeasureId)
                .HasColumnName("unit_measure_id")
                .IsRequired();

            builder.Property(e => e.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired();

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.Quotation)
                .WithMany(z => z.QuoteDetails)
                .HasForeignKey(e => e.QuotationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.UnitMeasure)
                .WithMany(z => z.QuoteDetails)
                .HasForeignKey(e => e.UnitMeasureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Supplier)
                .WithMany(z => z.QuoteDetails)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Product)
                .WithMany(z => z.QuoteDetails)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}