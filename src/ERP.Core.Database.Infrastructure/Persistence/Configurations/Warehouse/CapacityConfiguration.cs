using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class CapacityConfiguration : IEntityTypeConfiguration<Capacity>
{
    public void Configure(EntityTypeBuilder<Capacity> builder)
    {
        builder.ToTable("capacities");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("capacity_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(c => c.Witdh)
            .HasColumnName("width")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.Length)
            .HasColumnName("length")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.MinimumHeight)
            .HasColumnName("minimum_height")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(c => c.MaximumHeight)
            .HasColumnName("maximum_height")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(c => c.HasSpaceBetweenWall)
            .HasColumnName("has_space_between_wall")
            .IsRequired();

        builder.Property(c => c.AvailableSpaceWithSpacingM2)
            .HasColumnName("available_space_with_spacing_m2")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.AvailableSpaceWithoutSpacingM2)
            .HasColumnName("available_space_without_spacing_m2")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.PercenteAvailableSpaceWithSpacingM2)
            .HasColumnName("percent_available_space_with_spacing_m2")
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(c => c.PercenteAvailableSpaceWithSpacingM3)
            .HasColumnName("percent_available_space_with_spacing_m3")
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(c => c.AvailableSpaceWithSpacingM3)
            .HasColumnName("available_space_with_spacing_m3")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(c => c.AvailableSpaceWithoutSpacingM3)
            .HasColumnName("available_space_without_spacing_m3")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(c => c.SpacingTop)
            .HasColumnName("spacing_top")
            .HasPrecision(18, 2)
            .HasDefaultValue(0)
            .IsRequired(false);

        builder.Property(c => c.SpacingBotton)
            .HasColumnName("spacing_bottom")
            .HasPrecision(18, 2)
            .HasDefaultValue(0)
            .IsRequired(false);

        builder.Property(c => c.SpacingRight)
            .HasColumnName("spacing_right")
            .HasPrecision(18, 2)
            .HasDefaultValue(0)
            .IsRequired(false);

        builder.Property(c => c.SpacingLeft)
            .HasColumnName("spacing_left")
            .HasPrecision(18, 2)
            .HasDefaultValue(0)
            .IsRequired(false);

        builder.Property(c => c.UnusedSpaceM2)
            .HasColumnName("unused_space_m2")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(c => c.UnasedSpaceM3)
            .HasColumnName("unused_space_m3")
            .HasPrecision(18, 2)
            .IsRequired(false);

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