using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Authentication
{
    public class NotificationsConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("notifications");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("notification_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(e => e.PathRedirect)
                .HasColumnName("path_redirect")
                .IsRequired();

            builder.Property(e => e.AdditionalData)
                .HasColumnName("additional_data")
                .HasColumnType("jsonb")
                .IsRequired(false);
             
            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.HasOne(e => e.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}