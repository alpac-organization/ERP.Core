using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory;

public class SupplyRequestItemConfiguration : IEntityTypeConfiguration<SupplyRequestItem>
{
    public void Configure(EntityTypeBuilder<SupplyRequestItem> builder)
    {
        builder.ToTable("supply_request_item");
        builder.HasKey(sri => sri.Id);

        builder.Property(sri => sri.Id)
            .HasColumnName("supply_request_item_id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(sri => sri.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(sri => sri.ProductStockId)
            .HasColumnName("product_stock_id")
            .IsRequired();

        builder.Property(sri => sri.Amount)
            .HasColumnName("amount")
            .HasPrecision(5,2)
            .IsRequired();

        builder.Property(sri => sri.ReasonUse)
            .HasColumnName("reason_use")
            .HasColumnType("reason_use_enum")
            .HasDefaultValueSql("'sale'::reason_use_enum")
            .IsRequired();

        builder.Property(sri => sri.SupplyRequestId)
            .HasColumnName("supply_request_id")
            .IsRequired();

        #region Relaciones

        builder.HasOne(sri => sri.ProductStock)
            .WithMany()
            .HasForeignKey(sri => sri.ProductStockId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sri => sri.SupplyRequest)
            .WithMany()
            .HasForeignKey(sri => sri.SupplyRequestId)
            .OnDelete(DeleteBehavior.Restrict);
        
        #endregion
    }
}