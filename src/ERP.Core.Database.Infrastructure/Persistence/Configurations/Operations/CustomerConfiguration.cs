using ERP.Core.Database.Domain.Entities.Operations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.ToTable("customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("customer_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(c => c.LegalName)
                .HasColumnName("legal_name")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(c => c.CustomerCode)
                .HasColumnName("customer_code")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(c => c.IdentificationNumber)
                .HasColumnName("identification_number")
                .IsRequired(false);

            builder.Property(c => c.CustomerType)
                .HasColumnName("customer_type")
                .HasColumnType("customer_type_enum")
                .HasDefaultValueSql("'juridical'::customer_type_enum")
                .IsRequired();

            builder.Property(c => c.IdentificationType)
                .HasColumnName("identification_type")
                .HasColumnType("identification_type_enum")
                .HasDefaultValueSql("'ruc'::identification_type_enum")
                .IsRequired();

            builder.Property(c => c.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(c => c.Company)
                .WithMany(co => co.Customers)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.OperationalOrders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => c.CustomerCode)
                .HasDatabaseName("ix_customers_customer_code")
                .IsUnique();

            builder.HasIndex(c => c.IdentificationNumber)
                .HasDatabaseName("ix_customers_identification_number");
        }
    }
}