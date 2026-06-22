using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs.Warehouse;

public class CustomerTypeConfiguration : IEntityTypeConfiguration<CustomerType>
{
    public void Configure(EntityTypeBuilder<CustomerType> builder)
    {
        builder.ToTable("CustometType");

        builder.HasKey(ct => ct.Id);

        builder.Property(ct => ct.Code)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(ct => ct.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(ct => ct.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder.HasIndex(ct => ct.Code)
            .HasFilter("[DeletedAt] IS NULL")
            .IsUnique();

        builder.HasQueryFilter(ct => ct.DeletedAt == null);
    }
}