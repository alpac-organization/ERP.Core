using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class SectionCoordinatesConfiguration : IEntityTypeConfiguration<SectionCoordinates>
{
    public void Configure(EntityTypeBuilder<SectionCoordinates> builder)
    {
        builder.ToTable("section_coordinates");

        builder.Property(sc => sc.SectionId)
            .HasColumnName("section_id")
            .IsRequired();

        builder.HasOne(sc => sc.Section)
            .WithOne(s => s.SectionCoordinates)
            .HasForeignKey<SectionCoordinates>(sc => sc.SectionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
