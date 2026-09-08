using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class SectionCapacityConfiguration : IEntityTypeConfiguration<SectionCapacity>
{
    public void Configure(EntityTypeBuilder<SectionCapacity> builder)
    {
        builder.ToTable("section_capacities");

        builder.Property(sc => sc.UsableAreaM2)
            .HasColumnName("usable_area_m2")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(sc => sc.UnusableAreaM2)
            .HasColumnName("unusable_area_m2")
            .HasPrecision(18, 2)
            .IsRequired(false);

        builder.Property(sc => sc.SectionId)
            .HasColumnName("section_id")
            .IsRequired();

        builder.HasOne(sc => sc.Section)
            .WithOne(s => s.SectionCapacity)
            .HasForeignKey<SectionCapacity>(sc => sc.SectionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
