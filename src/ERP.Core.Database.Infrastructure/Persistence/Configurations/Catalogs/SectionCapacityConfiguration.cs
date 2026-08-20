using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class SectionCapacityConfiguration : IEntityTypeConfiguration<SectionCapacity>
{
    public void Configure(EntityTypeBuilder<SectionCapacity> builder)
    {
        builder.ToTable("section_capacities");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("section_capacity_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.SectionId)
            .HasColumnName("section_id")
            .IsRequired();

        builder.Property(e => e.UsableAreaM2)
            .HasColumnName("usable_area_m2")
            .HasPrecision(10, 2);

        builder.Property(e => e.UnusableAreaM2)
            .HasColumnName("unusable_area_m2")
            .HasPrecision(10, 2);

        builder.Property(e => e.LastCalculatedAt)
            .HasColumnName("last_calculated_at");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        // Relación 1:1 con Sections
        builder.HasIndex(e => e.SectionId)
            .IsUnique()
            .HasDatabaseName("ux_section_capacities_section_id");

        builder.HasOne(x => x.Section)
            .WithOne(x => x.Capacity)
            .HasForeignKey<SectionCapacity>(x => x.SectionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}