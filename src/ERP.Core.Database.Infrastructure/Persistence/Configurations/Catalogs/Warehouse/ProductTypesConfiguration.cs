using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs.Warehouse;

public class ProductTypesConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.ToTable("ProductType");

        builder.HasKey(pt => pt.Id);

        builder.Property(pt => pt.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(pt => pt.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder.HasQueryFilter(pt => pt.DeletedAt == null);
    }
}