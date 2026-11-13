using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Notifications;
using ERP.Core.Database.Domain.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Notifications
{
    public class NotificationRecipientConfigConfiguration : IEntityTypeConfiguration<NotificationRecipientConfig>
    {
        public void Configure(EntityTypeBuilder<NotificationRecipientConfig> builder)
        {
            builder.ToTable("notification_recipient_config");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("notification_recipient_config_id")
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

            builder.Property(e => e.RecipientType)
                .HasColumnName("recipient_type")
                .HasConversion<int>()
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired(false);

            builder.Property(e => e.RoleId)
                .HasColumnName("role_id")
                .IsRequired(false);

            builder.Property(e => e.SendEmail)
                .HasColumnName("send_email")
                .IsRequired();

            builder.Property(e => e.SendPush)
                .HasColumnName("send_push")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .IsRequired();

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

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => new { e.CompanyId, e.BranchId, e.Module, e.EventKey, e.RecipientType, e.UserId, e.RoleId })
                .HasDatabaseName("ux_notification_recipient_config");
        }
    }
}
