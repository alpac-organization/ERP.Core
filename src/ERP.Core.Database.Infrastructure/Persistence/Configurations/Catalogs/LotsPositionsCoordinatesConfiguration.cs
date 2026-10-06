using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class LotsPositionsCoordinatesConfiguration : IEntityTypeConfiguration<LotsPositionsCoordinates>
{
    public void Configure(EntityTypeBuilder<LotsPositionsCoordinates> builder)
    {
        builder.ToTable("lots_positions_coordinates");

        builder.Property(lpc => lpc.LotPositionId)
            .HasColumnName("lot_position_id")
            .IsRequired();

        builder.HasIndex(lpc => lpc.LotPositionId)
            .IsUnique()
            .HasDatabaseName("ux_lots_positions_coordinates_lot_position_id");

        builder.HasOne(lpc => lpc.LotPosition)
            .WithOne(lp => lp.LotsPositionsCoordinates)
            .HasForeignKey<LotsPositionsCoordinates>(lpc => lpc.LotPositionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}