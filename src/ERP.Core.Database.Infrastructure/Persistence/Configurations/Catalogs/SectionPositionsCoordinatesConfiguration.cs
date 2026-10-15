using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class SectionPositionsCoordinatesConfiguration : IEntityTypeConfiguration<SectionPositionsCoordinates>
{
    public void Configure(EntityTypeBuilder<SectionPositionsCoordinates> builder)
    {
        builder.ToTable("section_positions_coordinates");

        builder.Property(spc => spc.SectionPositionId)
            .HasColumnName("section_position_id")
            .IsRequired();

        builder.HasOne(spc => spc.SectionPosition)
            .WithOne(sp => sp.SectionPositionsCoordinates)
            .HasForeignKey<SectionPositionsCoordinates>(spc => spc.SectionPositionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
