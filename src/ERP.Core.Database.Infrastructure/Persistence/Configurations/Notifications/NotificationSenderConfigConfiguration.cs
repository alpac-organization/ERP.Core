using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Notifications;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Notifications
{
    public class NotificationSenderConfigConfiguration : IEntityTypeConfiguration<NotificationSenderConfig>
    {
        public void Configure(EntityTypeBuilder<NotificationSenderConfig> builder)
        {
            builder.ToTable("notification_sender_config");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("notification_sender_config_id")
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

            builder.Property(e => e.FromEmail)
                .HasColumnName("from_email");

            builder.Property(e => e.FromName)
                .HasColumnName("from_name");

            builder.Property(e => e.SmtpHost)
                .HasColumnName("smtp_host");

            builder.Property(e => e.SmtpPort)
                .HasColumnName("smtp_port")
                .IsRequired();

            builder.Property(e => e.SmtpUser)
                .HasColumnName("smtp_user");

            builder.Property(e => e.SmtpPasswordEnc)
                .HasColumnName("smtp_password_enc");

            builder.Property(e => e.UseSsl)
                .HasColumnName("use_ssl")
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
        }
    }
}
