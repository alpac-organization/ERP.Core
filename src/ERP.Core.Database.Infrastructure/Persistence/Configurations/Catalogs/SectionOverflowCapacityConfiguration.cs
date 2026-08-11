using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class SectonOverflowCapacityConfiguration : IEntityTypeConfiguration<SectionOverflowCapacity>
{
    public void Configure(EntityTypeBuilder<SectionOverflowCapacity> builder)
    {
        builder.ToTable("section_overflow_capacities");
        builder.HasKey(w => w.Id);

        builder.Property(o => o.Id)
            .HasColumnName("section_overflow_capacity_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(o => o.SectionId)
            .HasColumnName("section_id")
            .IsRequired();

        builder.Property(o => o.AllowsOverflowStorage)
            .HasColumnName("allows_overflow_storage")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(o => o.IsOverflowEnabled)
            .HasColumnName("is_overflow_enabled")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(o => o.MaxOverflowPolines)
            .HasColumnName("max_overflow_polines")
            .IsRequired(false);

        builder.Property(o => o.EnabledByUserName)
            .HasColumnName("enabled_by_user_name")
            .HasMaxLength(150)
            .IsRequired(false);

        builder.Property(o => o.EnabledDate)
            .HasColumnName("enabled_date")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(o => o.EnabledTime)
            .HasColumnName("enabled_time")
            .HasColumnType("time without time zone")
            .IsRequired(false);

        builder.Property(o => o.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(o => o.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        // Relación 1-1 con Sección
        builder.HasOne(o => o.Section)
            .WithOne(s => s.OverflowCapacity)
            .HasForeignKey<SectionOverflowCapacity>(o => o.SectionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(o => o.SectionId)
            .IsUnique()
            .HasDatabaseName("ix_section_overflow_capacities_section_id");
    }
}