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

            builder.Property(e => e.UnitPrice)
                .HasColumnName("unit_price")
                .HasPrecision(18, 2)
                .IsRequired();

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

            builder.HasOne(e => e.SupplierProduct)
                .WithMany(sp => sp.PriceHistories)
                .HasForeignKey(e => e.SupplierProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
