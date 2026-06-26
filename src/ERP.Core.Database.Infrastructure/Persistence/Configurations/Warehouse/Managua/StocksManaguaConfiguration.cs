using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class StocksManaguaConfiguration : IEntityTypeConfiguration<StocksManagua>
{
    public void Configure(EntityTypeBuilder<StocksManagua> builder)
    {
        builder.ToTable("stocks_managua");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("stock_id")
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(e => e.RackId)
            .HasColumnName("rack_id")
            .IsRequired();
        
        builder.Property(e => e.ProductId)
            .HasColumnName("product_id")
            .IsRequired();
        
        builder.Property(e => e.Quantity)
            .HasColumnName("quantity")
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(e => e.StoredAt)
            .HasColumnName("stored_at")
            .IsRequired();
        
        builder.Property(e => e.RowVersion)
            .IsRowVersion();
    }
}