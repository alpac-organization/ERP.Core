using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Shopping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class PurchaseOrdersConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.ToTable("purchase_orders");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("purchase_order_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            //Agregar las siguiente columnas de la tabla como tal.
            builder.Property(e => e.SentToReviewAt)
                .HasColumnName("send_to_review_at")
                .HasColumnType("date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.Comments)
                .HasColumnName("comments")
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(e => e.ReviewedByUserId)
                .HasColumnName("reviewed_by_user_id")
                .IsRequired(false);

            builder.Property(e => e.SentByUserId)
                .HasColumnName("send_by_user_id")
                .IsRequired();

            builder.Property(e => e.PurchaseRequestId)
                .HasColumnName("purchase_request_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.PurchaseRequest)
                .WithOne(pr => pr.PurchaseOrder)
                .HasForeignKey<PurchaseOrder>(e => e.PurchaseRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SentByUser)
                .WithMany(u => u.SentPurchaseOrder)
                .HasForeignKey(x => x.SentByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ReviewedByUser)
                .WithMany(u => u.ReviewedPurchaseOrder)
                .HasForeignKey(x => x.ReviewedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}