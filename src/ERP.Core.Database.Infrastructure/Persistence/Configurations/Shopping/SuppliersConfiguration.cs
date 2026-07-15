using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class SuppliersConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("suppliers");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("suppliers_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.SuppliersLegalName)
                .HasColumnName("suppliers_legal_name")
                .IsRequired();

            builder.Property(e => e.IdentificationNumber)
                .HasColumnName("identification_number")
                .IsRequired();

            builder.Property(e => e.ConstitutionType)
                .HasColumnName("constitution_type")
                .HasColumnType("constitution_type_enum")
                .IsRequired();

            builder.Property(e => e.IdentificationType)
                .HasColumnName("identification_type")
                .HasColumnType("identification_type_enum")
                .IsRequired();

            builder.Property(e => e.Address)
                .HasColumnName("address")
                .IsRequired(false);

            builder.Property(e => e.ContactName)
                .HasColumnName("contact_name")
                .IsRequired(false);

            builder.Property(e => e.ContactEmail)
                .HasColumnName("contact_email")
                .IsRequired(false);

            builder.Property(e => e.ContactPhoneNumber)
                .HasColumnName("contact_phone_number")
                .IsRequired(false);

            builder.Property(e => e.EmailSupport)
                .HasColumnName("email_support")
                .IsRequired(false);

            builder.Property(e => e.RegisterBy)
                .HasColumnName("register_by")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");
        }
    }
}