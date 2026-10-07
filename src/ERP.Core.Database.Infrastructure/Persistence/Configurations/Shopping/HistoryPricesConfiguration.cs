using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class HistoryPricesConfiguration : IEntityTypeConfiguration<HistoryPrices>
    {
        public void Configure(EntityTypeBuilder<HistoryPrices> builder)
        {
            builder.ToTable("history_prices");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("history_price_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.PriceType)
                .HasColumnName("price_type")
                .HasColumnType("supplier_price_history_type_enum")
                .IsRequired();

            builder.Property(e => e.Price)
                .HasColumnName("price")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.MinQuantity)
                .HasColumnName("min_quantity")
                .IsRequired(false);

            builder.Property(e => e.EffectiveFrom)
                .HasColumnName("effective_from")
                .IsRequired();

            builder.Property(e => e.EffectiveTo)
                .HasColumnName("effective_to")
                .IsRequired();

            builder.Property(e => e.SupplierProductId)
                .HasColumnName("supplier_product_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasIndex(e => e.SupplierProductId)
                .HasDatabaseName("ix_history_prices_supplier_product_id");

            builder.HasIndex(e => new { e.SupplierProductId, e.PriceType })
                .HasDatabaseName("ix_history_prices_supplier_product_price_type");

            builder.HasOne(e => e.SupplierProduct)
                .WithMany(sp => sp.PriceHistories)
                .HasForeignKey(e => e.SupplierProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
