using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("customer_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(c => c.Cif)
            .HasColumnName("cif")
            .IsRequired();

        builder.Property(c => c.PictureUrl)
            .HasColumnName("picture_url")
            .IsRequired();

        builder.Property(c => c.LegalName)
            .HasColumnName("legal_name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(c => c.IdentificationType)
            .HasColumnName("identification_type")
            .HasColumnType("identification_type_enum")
            .IsRequired();

        builder.Property(c => c.CustomerTypeId)
            .HasColumnName("customer_type_id")
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

        builder.HasOne(c => c.CustomerType)
            .WithMany(t => t.Customers)
            .HasForeignKey(c => c.CustomerTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Company)
            .WithMany(t => t.Customers)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(c => c.IdentificationNumber)
            .HasDatabaseName("ux_customer_identification")
            .IsUnique();

        builder.HasIndex(c => c.IdentificationNumber)
            .HasDatabaseName("ix_customer_cif_unique_code")
            .IsUnique();
    }
}