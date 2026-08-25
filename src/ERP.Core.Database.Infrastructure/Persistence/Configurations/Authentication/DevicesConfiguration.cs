using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Authentication
{
    public class DevicesConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("devices");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("device_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.DeviceName)
                .HasColumnName("device_name")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.EndpointArn)
                .HasColumnName("endpoint_arn")
                .IsRequired();

            builder.Property(e => e.FcmToken)
                .HasColumnName("fcm_token")
                .IsRequired();

            builder.Property(e => e.UserProfileId)
                .HasColumnName("user_profile_id")
                .IsRequired();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.HasOne(e => e.UserProfile)
                .WithMany(u => u.Devices)
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => e.FcmToken)
                .HasDatabaseName("ix_devices_fcm_token");
        }
    }
    
}