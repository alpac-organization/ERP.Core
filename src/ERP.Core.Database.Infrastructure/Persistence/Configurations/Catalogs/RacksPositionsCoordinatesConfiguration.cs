using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class RacksPositionsCoordinatesConfiguration : IEntityTypeConfiguration<RacksPositionsCoordinates>
{
    public void Configure(EntityTypeBuilder<RacksPositionsCoordinates> builder)
    {
        builder.ToTable("rack_positions_coordinates");

        builder.Property(rpc => rpc.RackPositionId)
            .HasColumnName("rack_position_id")
            .IsRequired();

        builder.HasIndex(rpc => rpc.RackPositionId)
            .IsUnique()
            .HasDatabaseName("ux_rack_positions_coordinates_rack_position_id");

        builder.HasOne(rpc => rpc.RackPosition)
            .WithOne(rp => rp.RacksPositionsCoordinates)
            .HasForeignKey<RacksPositionsCoordinates>(rpc => rpc.RackPositionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}