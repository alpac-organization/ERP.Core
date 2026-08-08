using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehouseDetailsConfiguration : IEntityTypeConfiguration<WarehouseDetails>
{
    public void Configure(EntityTypeBuilder<WarehouseDetails> builder)
    {
        builder.ToTable("warehouse_details");
        builder.HasKey(wd => wd.Id);

        builder.Property(wd => wd.Id)
            .HasColumnName("warehouse_details_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(w => w.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();
        
        builder.Property(w => w.WitdhMetres)
            .HasColumnName("width_metres")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.LengthMetres)
            .HasColumnName("length_metres")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.RampsCount)
            .HasColumnName("ramps_count")
            .IsRequired(false);

        builder.Property(w => w.ParkingSpacesCount)
            .HasColumnName("parking_spaces_count")
            .IsRequired(false);

        builder.Property(w => w.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(w => w.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        builder.HasOne(wd => wd.Warehouse)
            .WithOne(w => w.Details)
            .HasForeignKey<WarehouseDetails>(wd => wd.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(w => w.WarehouseId)
            .IsUnique()
            .HasDatabaseName("ix_warehouse_deatils_warehouse_id");
    }
}