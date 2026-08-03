using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Shopping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class PurchaseRequests : IEntityTypeConfiguration<PurchaseRequest>
    {
        public void Configure(EntityTypeBuilder<PurchaseRequest> builder)
        {
            builder.ToTable("purchase_requests");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("purchase_request_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.RequestDate)
                .HasColumnName("request_date")
                .IsRequired();

            builder.Property(e => e.RequestType)
                .HasColumnName("request_type")
                .HasColumnType("purchase_request_type_enum")
                .IsRequired();

            builder.Property(e => e.RequestStatus)
                .HasColumnName("request_status")
                .HasColumnType("purchase_request_status_enum")
                .HasDefaultValueSql("'pending'::purchase_request_status_enum")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .IsRequired();

            builder.Property(e => e.UserRevisionId)
                .HasColumnName("user_revision_id")
                .IsRequired(false);

            builder.Property(e => e.Justification)
                .HasColumnName("justification")
                .HasMaxLength(1000);

            builder.Property(e => e.ReasonRejection)
                .HasColumnName("reason_rejection")
                .HasMaxLength(1000);

            builder.Property(e => e.RevisionDate)
                .HasColumnName("revision_date");

            builder.Property(e => e.BranchId)
                .HasColumnName("branch_id")
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(e => e.AreaId)
                .HasColumnName("area_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");
                
            builder.HasOne(e => e.WorkArea)
                .WithMany(rp => rp.PurchaseRequests)
                .HasForeignKey(e => e.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Branch)
                .WithMany(rp => rp.PurchaseRequests)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.User)
                .WithMany(rp => rp.PurchaseRequests)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.RequestdProducts)
                .WithOne(rp => rp.PurchaseRequest)
                .HasForeignKey(rp => rp.PurchaseRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.RequestQuotedPurchases)
                .WithOne(rq => rq.PurchaseRequest)
                .HasForeignKey(rq => rq.PurchaseRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}