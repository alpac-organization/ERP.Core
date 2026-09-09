using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class BaseCapacityConfiguration : IEntityTypeConfiguration<BaseCapacity>
{
    public void Configure(EntityTypeBuilder<BaseCapacity> builder)
    {
        builder.UseTpcMappingStrategy();
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("capacity_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(c => c.Width)
            .HasColumnName("width")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.Length)
            .HasColumnName("length")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.UnusedAreaM2)
            .HasColumnName("unused_area_m2")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.AvailableAreaWithMarginM2)
            .HasColumnName("available_area_with_margin_m2")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.TotalAreaM2)
            .HasColumnName("total_area_m2")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.UnoccupiedChargeableAreaM2)
            .HasColumnName("unoccupied_chargeable_area_m2")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.OccupiedChargeableAreaM2)
            .HasColumnName("occupied_chargeable_area_m2")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.PercentageAvailableAreaWithMarginM2)
            .HasColumnName("percentage_available_area_with_margin_m2")
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(c => c.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);
    }
}
