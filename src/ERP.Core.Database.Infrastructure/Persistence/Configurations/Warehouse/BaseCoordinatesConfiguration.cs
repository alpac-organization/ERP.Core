using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class BaseCoordinatesConfiguration : IEntityTypeConfiguration<BaseCoordinates>
{
    public void Configure(EntityTypeBuilder<BaseCoordinates> builder)
    {
        builder.UseTpcMappingStrategy();
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("coordinate_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(c => c.PositionX)
            .HasColumnName("position_x")
            .HasPrecision(18, 6)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(c => c.PositionY)
            .HasColumnName("position_y")
            .HasPrecision(18, 6)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(c => c.PositionZ)
            .HasColumnName("position_z")
            .HasPrecision(18, 6)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(c => c.RotationY)
            .HasColumnName("rotation_y")
            .HasPrecision(18, 6)
            .HasDefaultValue(0m)
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
