using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Notifications;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Notifications
{
    public class NotificationDeliveryConfiguration : IEntityTypeConfiguration<NotificationDelivery>
    {
        public void Configure(EntityTypeBuilder<NotificationDelivery> builder)
        {
            builder.ToTable("notification_delivery");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("notification_delivery_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.OutboxId)
                .HasColumnName("outbox_id")
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(e => e.Channel)
                .HasColumnName("channel")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(e => e.IdempotencyKey)
                .HasColumnName("idempotency_key")
                .IsRequired();

            builder.Property(e => e.SentAt)
                .HasColumnName("sent_at")
                .IsRequired(false);

            builder.Property(e => e.Error)
                .HasColumnName("error")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.Outbox)
                .WithMany()
                .HasForeignKey(e => e.OutboxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => e.IdempotencyKey)
                .IsUnique()
                .HasDatabaseName("ux_notification_delivery_idempotency_key");
        }
    }
}
