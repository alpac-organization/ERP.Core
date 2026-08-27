using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class LayoutTransformConfiguration : IEntityTypeConfiguration<LayoutTransform>
{
    public void Configure(EntityTypeBuilder<LayoutTransform> builder)
    {
        builder.ToTable("layout_transforms");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("layout_transform_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.PositionX)
            .HasColumnName("position_x")
            .HasPrecision(10, 0)
            .HasDefaultValue(0m)
            .IsRequired();


        builder.Property(e => e.PositionY)
            .HasColumnName("position_y")
            .HasPrecision(10, 0)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.PositionZ)
            .HasColumnName("position_z")
            .HasPrecision(10, 0)
            .HasDefaultValue(0m)
            .IsRequired();


        builder.Property(e => e.PositionY)
            .HasColumnName("position_y")
            .HasPrecision(10, 0)
            .HasDefaultValue(0m)
            .IsRequired();


        builder.Property(e => e.SectionId).HasColumnName("section_id");
        builder.Property(e => e.RackId).HasColumnName("rack_id");
        builder.Property(e => e.LotId).HasColumnName("lot_id");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.Sections)
            .WithOne(s => s.LayoutTransform)
            .HasForeignKey<LayoutTransform>(e => e.SectionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Rack)
            .WithOne(s => s.LayoutTransform)
            .HasForeignKey<LayoutTransform>(e => e.RackId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(e => e.Lot)
            .WithOne(s => s.LayoutTransform)
            .HasForeignKey<LayoutTransform>(e => e.LotId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.SectionId)
            .IsUnique()
            .HasDatabaseName("ux_layout_transforms_section_id")
            .HasFilter("section_id IS NOT NULL");

        builder.HasIndex(e => e.RackId)
            .IsUnique()
            .HasDatabaseName("ux_layout_transforms_rack_id")
            .HasFilter("rack_id IS NOT NULL");

        builder.HasIndex(e => e.LotId)
            .IsUnique()
            .HasDatabaseName("ux_layout_transforms_lot_id")
            .HasFilter("lot_id IS NOT NULL");
    }
}