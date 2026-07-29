using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Shopping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class RequestQuotedPurchasesConfiguration : IEntityTypeConfiguration<RequestQuotedPurchases>
    {
        public void Configure(EntityTypeBuilder<RequestQuotedPurchases> builder)
        {
            builder.ToTable("request_quoted_purchases");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("request_quoted_purchases_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.PurchaseRequestId)
                .HasColumnName("purchase_request_id")
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

            // Relaciones
            builder.HasOne(e => e.PurchaseRequest)
                .WithMany(pr => pr.RequestQuotedPurchases)
                .HasForeignKey(e => e.PurchaseRequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(e => e.Quotation)
                .WithMany(pq => pq.RequestQuotedPurchases)
                .HasForeignKey(e => e.QuotationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}