using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class LotsConfiguration : IEntityTypeConfiguration<Lots>
{
   public void Configure(EntityTypeBuilder<Lots> builder)
   {
      builder.ToTable("lots");
      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id)
          .HasColumnName("tramo_id")
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

      builder.Property(e => e.PositionX)
           .HasColumnName("position_x")
           .HasPrecision(10, 2)
           .IsRequired();

      builder.Property(e => e.PositionY)
           .HasColumnName("position_y")
           .HasPrecision(10, 2)
           .IsRequired();

      builder.Property(e => e.PositionZ)
           .HasColumnName("position_z")
           .HasPrecision(10, 2)
           .IsRequired();

      builder.Property(e => e.RotationY)
         .HasColumnName("rotation_y")
         .HasPrecision(10, 2)
         .IsRequired();

      builder.Property(e => e.NominalRows)
          .HasColumnName("nominal_rows")
          .IsRequired();

      builder.Property(e => e.NominalColumns)
          .HasColumnName("nominal_columns")
          .IsRequired();

      builder.Property(e => e.AllowsStacking)
          .HasColumnName("allows_stacking")
          .HasDefaultValue(true)
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

      builder.Property(e => e.CreatedAt)
          .HasColumnName("created_at")
          .HasDefaultValueSql("CURRENT_TIMESTAMP")
          .ValueGeneratedOnAdd();

      builder.Property(e => e.DeletedAt)
          .HasColumnName("deleted_at");

      builder.HasIndex(e => new { e.SectionId, e.Code })
          .IsUnique()
          .HasDatabaseName("ix_tramos_section_id_code");

      builder.HasIndex(e => e.SectionId)
          .HasDatabaseName("ix_tramos_section_id");

      builder.HasOne(e => e.Section)
          .WithMany(s => s.Lots)
          .HasForeignKey(e => e.SectionId)
          .OnDelete(DeleteBehavior.Restrict);
   }
}