using ERP.Core.Database.Domain.Entities.Inventory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.ToTable("product_stock");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("product_stock_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .IsRequired();

            builder.Property(e => e.AvailableQuantity)
                .HasColumnName("available_quantity")
                .IsRequired();

            builder.Property(e => e.MinimumStock)
                .HasColumnName("minimum_stock")
                .IsRequired();

            builder.Property(e => e.MaximumStock)
                .HasColumnName("maximum_stock");

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("product_stock_status_enum")
                .HasDefaultValueSql("'stable'::product_stock_status_enum")
                .IsRequired();

            builder.Property(e => e.WeightedAverageCost)
                .HasColumnName("weightd_average_cost")
                .HasPrecision(8, 2)
                .IsRequired();

            builder.Property(e => e.UnitMeasureId)
                .HasColumnName("unit_measure_id")
                .IsRequired();

            builder.Property(e => e.CostCenterId)
                .HasColumnName("cost_center_id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.Product)
                .WithMany(e => e.ProductStocks)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CostCenter)
                .WithMany(e => e.ProductStocks)
                .HasForeignKey(e => e.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.UnitMeasure)
                .WithMany(u => u.ProductStocks)
                .HasForeignKey(p => p.UnitMeasureId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(e => new { e.ProductId, e.CostCenterId })
                .HasDatabaseName("ux_product_stock_product_costcenter");
        }
    }
}