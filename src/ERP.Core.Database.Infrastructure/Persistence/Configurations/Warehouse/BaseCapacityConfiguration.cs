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

        builder.Property(c => c.Witdh)
            .HasColumnName("width")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.Length)
            .HasColumnName("length")
            .HasPrecision(18, 2)
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
