using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ERP.Core.Database.Domain.Entities.Catalogs;
namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class RacksConfiguration : IEntityTypeConfiguration<Racks>
{
    public void Configure(EntityTypeBuilder<Racks> builder)
    {
        builder.ToTable("racks");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("rack_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.SectionId)
            .HasColumnName("section_id")
            .IsRequired();

        builder.Property(e => e.Code)
            .HasColumnName("code")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.WidthMetres)
            .HasColumnName("width_metres")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(e => e.LengthMetres)
            .HasColumnName("length_metres")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(e => e.HeightMetres)
            .HasColumnName("height_metres")
            .HasPrecision(10, 2)
            .IsRequired(false);

        builder.Property(e => e.UsageProfile)
            .HasColumnName("usage_profile")
            .HasColumnType("rack_usage_profile_enum")
            .HasDefaultValueSql("'active_flow'::rack_usage_profile_enum")
            .IsRequired();

        builder.Property(e => e.RowNumber)
            .HasColumnName("row_number")
            .IsRequired();

        builder.Property(e => e.LevelNumber)
            .HasColumnName("level_number")
            .IsRequired();

        builder.Property(e => e.MaxPulleys)
            .HasColumnName("max_pulleys")
            .HasDefaultValue(2)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("rack_status_enum")
            .HasDefaultValueSql("'available'::rack_status_enum")
            .IsRequired();

        builder.Property(e => e.UnavailableReason)
            .HasColumnName("unavailable_reason")
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(e => e.StatusChangedAt)
            .HasColumnName("status_changed_at")
            .IsRequired(false);

        builder.ComplexProperty(e => e.TransformWarehouse3D, layaout =>
        {
            layaout.IsRequired();

            layaout.Property(p => p.PositionX)
                   .HasColumnName("layout_position_x")
                   .HasPrecision(10, 2);

            layaout.Property(p => p.PositionY)
                   .HasColumnName("layout_position_y")
                   .HasPrecision(10, 2);

            layaout.Property(p => p.PositionZ)
                   .HasColumnName("layout_position_z")
                   .HasPrecision(10, 2);

            layaout.Property(p => p.RotationY)
                   .HasColumnName("layout_rotation_y")
                   .HasPrecision(10, 2);
        });

        builder.Property(e => e.CreatedAt)
           .HasColumnName("created_at")
           .HasDefaultValueSql("CURRENT_TIMESTAMP")
           .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasIndex(e => e.SectionId)
            .HasDatabaseName("ix_racks_section_id");

        builder.HasOne(e => e.Section)
            .WithMany(s => s.Racks)
            .HasForeignKey(e => e.SectionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.SectionId, e.Code })
            .IsUnique()
            .HasDatabaseName("ix_racks_section_id_code");
    }
}