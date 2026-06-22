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

        builder.Property(ct => ct.Id)
            .HasColumnName("type_customer_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(ct => ct.Code)
            .HasColumnName("type_customer_code")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(ct => ct.Name)
            .HasColumnName("type_customer_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(ct => ct.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.HasIndex(ct => ct.Code)
            .HasFilter("\"DeletedA\" IS NULL")
            .IsUnique();

        builder.HasQueryFilter(ct => ct.DeletedAt == null);
    }
}