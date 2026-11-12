using ERP.Core.Database.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory;

public class InventoryOutputsItemConfiguration : IEntityTypeConfiguration<InventoryOutputsItem>
{
    public void Configure(EntityTypeBuilder<InventoryOutputsItem> builder)
    {
        builder.ToTable("inventory_outputs_items");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("inventory_output_item_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(e => e.InventoryOutputId)
            .HasColumnName("inventory_output_id")
            .IsRequired();

        builder.Property(e => e.ProductStockId)
            .HasColumnName("product_stock_id")
            .IsRequired();

        builder.Property(e => e.DispatchedQuantity)
            .HasColumnName("dispatched_quantity")
            .IsRequired();

        builder.HasOne(e => e.InventoryOutput)
            .WithMany(e => e.InventoryOutputsItems)
            .HasForeignKey(e => e.InventoryOutputId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ProductStock)
            .WithMany(e => e.InventoryOutputsItems)
            .HasForeignKey(e => e.ProductStockId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}