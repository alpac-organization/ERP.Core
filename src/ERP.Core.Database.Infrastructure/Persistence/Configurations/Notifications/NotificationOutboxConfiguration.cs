using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Notifications;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Notifications
{
    public class NotificationOutboxConfiguration : IEntityTypeConfiguration<NotificationOutbox>
    {
        public void Configure(EntityTypeBuilder<NotificationOutbox> builder)
        {
            builder.ToTable("notification_outbox");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("notification_outbox_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();

            builder.Property(e => e.BranchId)
                .HasColumnName("branch_id")
                .IsRequired(false);

            builder.Property(e => e.Module)
                .HasColumnName("module")
                .IsRequired();

            builder.Property(e => e.EventKey)
                .HasColumnName("event_key")
                .IsRequired();

            builder.Property(e => e.Payload)
                .HasColumnName("payload")
                .IsRequired(false);

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(e => e.Attempts)
                .HasColumnName("attempts")
                .IsRequired();

            builder.Property(e => e.NextAttemptAt)
                .HasColumnName("next_attempt_at")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Branch)
                .WithMany()
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => new { e.Status, e.NextAttemptAt })
                .HasDatabaseName("ix_notification_outbox_status_next_attempt");
        }
    }
}
