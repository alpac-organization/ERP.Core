using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Authentication
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("user_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.UserName)
                .HasColumnName("user_name")
                .IsRequired();

            builder.Property(e => e.Fullname)
                .HasColumnName("fullname")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(e => e.AreaId)
                .HasColumnName("area_id");

            builder.Property(e => e.IdentificationNumber)
                .HasColumnName("identification_number")
                .IsRequired();

            builder.Property(u => u.UserType)
                .HasColumnName("user_type")
                .HasColumnType("user_type_enum")
                .IsRequired();

            builder.Property(e => e.UserStatus)
                .HasColumnName("user_status")
                .HasColumnType("user_status_enum")
                .IsRequired();

            builder.Property(e => e.PasswordHash)
                .HasColumnName("password_hash")
                .IsRequired();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.HasOne(e => e.WorkArea)
               .WithMany(u => u.Users)
               .HasForeignKey(e => e.AreaId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Profiles)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Sessions)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Suppliers)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Notifications)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}