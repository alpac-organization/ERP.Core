using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Shopping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class PurchaseRequestItemsConfiguration : IEntityTypeConfiguration<PurchaseRequestItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseRequestItem> builder)
        {
            builder.ToTable("purchase_request_items");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("purchase_request_item_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(e => e.QuantityUnit)
                .HasColumnName("quantity_unit");

            builder.Property(e => e.UnitMeasureId)
                .HasColumnName("unit_measure_id")
                .IsRequired();

            builder.Property(e => e.Justification)
                .HasColumnName("justification")
                .IsRequired(false);

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(e => e.PurchaseRequestId)
                .HasColumnName("purchase_request_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            // Relaciones
            builder.HasMany(u => u.Quotations)
                .WithOne(p => p.PurchaseRequestItem)
                .HasForeignKey(p => p.PurchaseRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.UnitMeasure)
                .WithMany(e => e.PurchaseRequestItems)
                .HasForeignKey(e => e.UnitMeasureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Product)
                .WithMany(e => e.PurchaseRequestItems)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PurchaseRequest)
                .WithMany(pr => pr.PurchaseRequestItems)
                .HasForeignKey(e => e.PurchaseRequestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}