using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class PurchaseRequestsReviewedManagementConfiguration : IEntityTypeConfiguration<PurchaseRequestsReviewedManagement>
    {
        public void Configure(EntityTypeBuilder<PurchaseRequestsReviewedManagement> builder)
        {
            builder.ToTable("purchase_requests_reviewed_management");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("purchase_requests_reviewed_management_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("management_review_status_enum")
                .HasDefaultValueSql("'pending'::management_review_status_enum")
                .IsRequired();
                
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
                .WithOne(pr => pr.ManagementReview)
                .HasForeignKey<PurchaseRequestsReviewedManagement>(e => e.PurchaseRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SentByUser)
                .WithMany(u => u.SentManagementReviews)
                .HasForeignKey(x => x.SentByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ReviewedByUser)
                .WithMany(u => u.ReviewedManagementReviews)
                .HasForeignKey(x => x.ReviewedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}