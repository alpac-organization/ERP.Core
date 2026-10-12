using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class PaymentRequestsConfiguration : IEntityTypeConfiguration<PaymentRequest>
    {
        public void Configure(EntityTypeBuilder<PaymentRequest> builder)
        {
            builder.ToTable("payment_requests");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("payment_request_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(e => e.Code)
                .IsUnique()
                .HasDatabaseName("ux_payment_requests_code")
                .HasFilter("\"deleted_at\" IS NULL");

            builder.Property(e => e.PaymentMethodType)
                .HasColumnName("payment_method_type")
                .HasColumnType("payment_method_type_enum")
                .IsRequired();

            builder.Property(e => e.PurchaseOrderId)
                .HasColumnName("purchase_order_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.PurchaseOrder)
                .WithOne(po => po.PaymentRequest)
                .HasForeignKey<PaymentRequest>(e => e.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
