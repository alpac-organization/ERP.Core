using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class CategoryProductsConfiguration : IEntityTypeConfiguration<CategoryProducts>
{
    public void Configure(EntityTypeBuilder<CategoryProducts> builder)
    {
        builder.ToTable("category_products");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("category_products_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(c => c.Code)
            .HasColumnName("code")
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();
    } 
}