using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations
{
    public class CustomerBranchConfiguration : IEntityTypeConfiguration<CustomerBranch>
    {
        public void Configure(EntityTypeBuilder<CustomerBranch> builder)
        {
            builder.ToTable("customer_branches");

            builder.HasKey(cb => cb.Id);

            builder.Property(cb => cb.Id)
                .HasColumnName("customer_branch_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(cb => cb.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(cb => cb.IsMainBranch)
                .HasColumnName("is_main_branch")
                .IsRequired();

            builder.Property(cb => cb.Code)
                .HasColumnName("code")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(cb => cb.Description)
                .HasColumnName("description")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(cb => cb.Address)
                .HasColumnName("address")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(cb => cb.Email)
                .HasColumnName("email")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(cb => cb.Phone)
                .HasColumnName("phone")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(cb => cb.Contact)
                .HasColumnName("contact")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(cb => cb.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(cb => cb.Customer)
                .WithMany(c => c.CustomerBranches)
                .HasForeignKey(cb => cb.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(cb => cb.CreditInformation)
                .WithOne(ci => ci.Branch)
                .HasForeignKey(ci => ci.BranchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(cb => cb.CustomerId)
                .HasDatabaseName("ix_customer_branches_customer_id");
        }
    }
}