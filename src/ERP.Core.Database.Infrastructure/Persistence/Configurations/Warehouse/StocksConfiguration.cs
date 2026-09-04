using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class StocksConfiguration : IEntityTypeConfiguration<Stocks>
{
    public void Configure(EntityTypeBuilder<Stocks> builder)
    {
        builder.ToTable("stocks");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("stock_id")
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(e => e.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();
        
        builder.Property(e => e.EntranceDucatsId)
            .HasColumnName("entrance_ducats_id")
            .IsRequired();
        
        builder.Property(e => e.RowVersion)
            .HasColumnName("row_version")
            .HasColumnType("xmin")
            .ValueGeneratedOnAddOrUpdate()
            .IsConcurrencyToken();

        builder.Property(e => e.MerchandiseId)
            .HasColumnName("merchandise_id")
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

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(x => x.EntranceDucat)
            .WithMany()
            .HasForeignKey(x => x.EntranceDucatsId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.CategoryProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Merchandise)
            .WithMany()
            .HasForeignKey(x => x.MerchandiseId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}