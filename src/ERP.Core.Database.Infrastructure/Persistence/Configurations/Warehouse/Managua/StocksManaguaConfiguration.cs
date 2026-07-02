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
        
        builder.Property(e => e.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();
        
        builder.Property(e => e.EntranceDucatsManaguaId)
            .HasColumnName("entrance_ducats_managua_id")
            .IsRequired();
        
        builder.Property(e => e.ZonesManaguaId)
            .HasColumnName("zone_managua_id")
            .IsRequired();
        
        builder.Property(e => e.RacksManaguaId)
            .HasColumnName("racks_managua_id")
            .IsRequired();
        
        builder.Property(e => e.CategoryProductId)
            .HasColumnName("category_product_id")
            .IsRequired();
        
        builder.Property(e => e.CurrentBultos)
            .HasColumnName("current_bultos")
            .IsRequired();
        
        builder.Property(e => e.CurrentWeightKg)
            .HasColumnName("current_weight_kg")
            .HasPrecision(18, 4)
            .IsRequired();
        
        builder.Property(e => e.StoredAt)
            .HasColumnName("stored_at")
            .IsRequired();

        builder.Property(e => e.RowVersion)
            .IsRowVersion();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(x => x.EntranceDucat)
            .WithMany()
            .HasForeignKey(x => x.EntranceDucatsManaguaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Rack)
            .WithMany(x => x.CurrentStock)
            .HasForeignKey(x => x.RacksManaguaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.CategoryProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Zone)
            .WithMany(x => x.CurrentStock)
            .HasForeignKey(x => x.ZonesManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}