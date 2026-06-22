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

        builder.Property(c => c.DNI_RUC)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(c => c.LegalName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder.HasIndex(c => c.DNI_RUC)
            .HasFilter("[DeletedAt] IS NULL")
            .IsUnique();

        builder.HasQueryFilter(c => c.DeletedAt == null);

        builder.HasOne(c => c.CustomerType)
            .WithMany()
            .HasForeignKey(c => c.CustomerTypeId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}