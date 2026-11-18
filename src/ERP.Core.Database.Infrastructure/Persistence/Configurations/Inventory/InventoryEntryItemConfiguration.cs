using ERP.Core.Database.Domain.Entities.Inventory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class InventoryEntryItemConfiguration : IEntityTypeConfiguration<InventoryEntryItem>
    {
        public void Configure(EntityTypeBuilder<InventoryEntryItem> builder)
        {
            builder.ToTable("inventory_entry_items");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("inventory_entry_item_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.InventoryEntryId)
                .HasColumnName("inventory_entry_id")
                .IsRequired();

            builder.Property(e => e.PurchaseOrderItemId)
                .HasColumnName("purchase_order_item_id")
                .IsRequired();

            builder.Property(e => e.CostCenterId)
                .HasColumnName("cost_center_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            #region Foreign Keys

            builder.HasOne(e => e.InventoryEntry)
                .WithMany(entry => entry.InventoryEntryItems)
                .HasForeignKey(e => e.InventoryEntryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.PurchaseOrderItem)
                .WithMany()
                .HasForeignKey(e => e.PurchaseOrderItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CostCenter)
                .WithMany()
                .HasForeignKey(e => e.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Indexes

            builder.HasIndex(e => new { e.InventoryEntryId, e.PurchaseOrderItemId })
                .IsUnique()
                .HasDatabaseName("ux_inventory_entry_items_entry_order_item");

            builder.HasIndex(e => e.PurchaseOrderItemId)
                .HasDatabaseName("ix_inventory_entry_items_purchase_order_item_id");

            builder.HasIndex(e => e.CostCenterId)
                .HasDatabaseName("ix_inventory_entry_items_cost_center_id");

            #endregion
        }
    }
}
