using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Shopping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class PurchaseOrderItemsConfiguration : IEntityTypeConfiguration<PurchaseOrderItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderItem> builder)
        {
            builder.ToTable("purchase_order_items");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("purchase_order_item_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(e => e.UnitPrice)
                .HasColumnName("unit_price")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.PurchaseOrderId)
                .HasColumnName("purchase_order_id")
                .IsRequired();

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(e => e.PurchaseRequestItemId)
                .HasColumnName("purchase_request_item_id")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasIndex(e => e.PurchaseOrderId)
                .HasDatabaseName("ix_purchase_order_items_purchase_order_id");

            builder.HasIndex(e => e.ProductId)
                .HasDatabaseName("ix_purchase_order_items_product_id");

            builder.HasIndex(e => e.PurchaseRequestItemId)
                .HasDatabaseName("ix_purchase_order_items_purchase_request_item_id");

            builder.HasOne(e => e.PurchaseOrder)
                .WithMany(po => po.PurchaseOrderItems)
                .HasForeignKey(e => e.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Product)
                .WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PurchaseRequestItem)
                .WithMany(pri => pri.PurchaseOrderItems)
                .HasForeignKey(e => e.PurchaseRequestItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
