using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class SectionPositionsConfiguration : IEntityTypeConfiguration<SectionPositions>
{
    public void Configure(EntityTypeBuilder<SectionPositions> builder)
    {
        builder.ToTable("section_positions");

        builder.Property(e => e.SectionId)
            .HasColumnName("section_id")
            .IsRequired();

        builder.HasIndex(e => e.SectionId)
            .HasDatabaseName("ix_section_positions_section_id");

        builder.HasOne(e => e.Section)
            .WithMany()
            .HasForeignKey(e => e.SectionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
