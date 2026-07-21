using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("product_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.HasIndex(p =>p.Id)
            .IsUnique()
            .HasDatabaseName("ix_product_id");

        builder.Property(p => p.ProductName)
            .HasColumnName("product_name")
            .IsRequired();

        builder.Property(p => p.UsageType)
            .HasColumnName("product_usage_type")
            .HasColumnType("product_usage_type_enum")
            .IsRequired();

        builder.Property(p => p.CategoryId)
            .HasColumnName("category_id")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(p => p.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}