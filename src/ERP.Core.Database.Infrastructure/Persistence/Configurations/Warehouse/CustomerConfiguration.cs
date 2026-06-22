using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("customer_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasIndex(c => c.Id)
            .IsUnique()
            .HasDatabaseName("ix_customer_id");

        builder.Property(c => c.DNI_RUC)
            .HasColumnName("dni_ruc")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(c => c.LegalName)
            .HasColumnName("legal_name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.HasOne(c => c.CustomerType)
            .WithOne()
            .HasForeignKey<Customer>(c => c.CustomerTypeId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}