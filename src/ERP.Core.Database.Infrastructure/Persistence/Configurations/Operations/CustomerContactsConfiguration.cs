using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations
{
    public class CustomerContactsConfiguration : IEntityTypeConfiguration<CustomerContacts>
    {
        public void Configure(EntityTypeBuilder<CustomerContacts> builder)
        {
            builder.ToTable("customer_contacts");

            builder.HasKey(cc => cc.Id);

            builder.Property(cc => cc.Id)
                .HasColumnName("customer_contact_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(cc => cc.ContactName)
                .HasColumnName("contact_name")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(cc => cc.Email)
                .HasColumnName("email")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(cc => cc.Position)
                .HasColumnName("position")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(cc => cc.IsPrimary)
                .HasColumnName("is_primary")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(cc => cc.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(cc => cc.BranchId)
                .HasColumnName("branch_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(cc => cc.Branch)
                .WithMany(cb => cb.Contacts)
                .HasForeignKey(cc => cc.BranchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(cc => cc.BranchId)
                .HasDatabaseName("ix_customer_contacts_branch_id");
        }
    }
}