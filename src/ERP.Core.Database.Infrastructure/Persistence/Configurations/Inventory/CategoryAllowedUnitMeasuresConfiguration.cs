using System.Runtime.InteropServices;
using ERP.Core.Database.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory;

public class CategoryAllowedUnitMeasuresConfiguration : IEntityTypeConfiguration<CategoryAllowedUnitMeasures>
{
    public void Configure(EntityTypeBuilder<CategoryAllowedUnitMeasures> builder)
    {
        builder.ToTable("category_allowed_unit_measures");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("category_allowed_unit_measure_id")
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

        builder.Property(c => c.UnitMeasureId)
            .HasColumnName("unit_measure_id")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(c => c.CategoryProducts)
            .WithMany(c => c.CategoryAllowedUnitMeasures)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.UnitMeasure)
            .WithMany(c => c.CategoryAllowedUnitMeasures)
            .HasForeignKey(c => c.UnitMeasureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}