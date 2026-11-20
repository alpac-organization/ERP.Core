using ERP.Core.Database.Domain.Entities.Inventory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class PhysicalCountLineConfiguration : IEntityTypeConfiguration<PhysicalCountLine>
    {
        public void Configure(EntityTypeBuilder<PhysicalCountLine> builder)
        {
            builder.ToTable("physical_count_lines");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("physical_count_line_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.PhysicalCountId)
                .HasColumnName("physical_count_id")
                .IsRequired();

            builder.Property(e => e.ProductStockId)
                .HasColumnName("product_stock_id")
                .IsRequired();

            builder.Property(e => e.SystemStock)
                .HasColumnName("system_stock")
                .HasPrecision(7, 2)
                .IsRequired();

            builder.Property(e => e.PhysicalStock)
                .HasColumnName("physical_stock")
                .HasPrecision(7, 2)
                .IsRequired(false);

            builder.Property(e => e.Difference)
                .HasColumnName("difference")
                .HasPrecision(7, 2)
                .IsRequired(false);

            builder.Property(e => e.Observations)
                .HasColumnName("observations")
                .IsRequired(false);

            builder.Property(e => e.CountedByUserId)
                .HasColumnName("counted_by_user_id")
                .IsRequired(false);

            builder.Property(e => e.CountedAt)
                .HasColumnName("counted_at")
                .IsRequired(false);

            builder.Property(e => e.UpdatedBy)
                .HasColumnName("updated_by")
                .IsRequired(false);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            #region Relations
            builder.HasOne(e => e.PhysicalCount)
                .WithMany(e => e.Lines)
                .HasForeignKey(e => e.PhysicalCountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.ProductStock)
                .WithMany(e => e.PhysicalCountLines)
                .HasForeignKey(e => e.ProductStockId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion Relations

            builder.HasIndex(e => new { e.PhysicalCountId, e.ProductStockId })
                .IsUnique()
                .HasDatabaseName("ux_physical_count_line_count_productstock");
        }
    }
}