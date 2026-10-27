using System.Runtime.InteropServices;
using ERP.Core.Database.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory;

public class InventoryAllowedCategoriesConfiguration : IEntityTypeConfiguration<InventoryAllowedCategories>
{
    public void Configure(EntityTypeBuilder<InventoryAllowedCategories> builder)
    {
        builder.ToTable("inventory_allowed_categories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("inventory_allowed_category_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(c => c.CategoryId)
            .HasColumnName("category_id")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");
            
        builder.HasOne(c => c.CategoryProducts)
            .WithMany(c => c.InventoryAllowedCategories)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}