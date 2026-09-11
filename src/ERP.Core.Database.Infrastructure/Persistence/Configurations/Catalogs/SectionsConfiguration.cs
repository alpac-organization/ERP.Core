using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
    public class SectionsConfiguration : IEntityTypeConfiguration<Sections>
    {
        public void Configure(EntityTypeBuilder<Sections> builder)
        {
            builder.ToTable("sections");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("section_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.WarehouseId)
                .HasColumnName("warehouse_id")
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.WarehouseId)
                .HasColumnName("warehouse_id")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(w => w.SectionType)
                .HasColumnName("section_type")
                .HasColumnType("section_type_enum")
                .HasDefaultValueSql("'storage'::section_type_enum")
                .IsRequired();

            builder.Property(w => w.SectionStorageType)
                .HasColumnName("section_storage_type")
                .HasColumnType("section_storage_type_enum")
                .HasDefaultValueSql("'racks'::section_storage_type_enum")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasIndex(s => s.WarehouseId)
                .HasDatabaseName("ix_sections_warehouse_id");

            builder.HasOne(x => x.Warehouse)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.AllowsStorageAisle)
                .HasColumnName("allows_storage_aisle")
                .HasDefaultValue(false)
                .IsRequired(false);

            builder.Property(o => o.IsStorageEnabledAisle)
                .HasColumnName("is_storage_enable_aisle")
                .HasDefaultValue(false)
                .IsRequired(false);

            builder.Property(o => o.MaxPalletsPerLevelAisle)
                .HasColumnName("max_pallets_per_level_aisle")
                .IsRequired(false);

            builder.Property(o => o.EnabledByUserName)
                .HasColumnName("enabled_by_user_name")
                .IsRequired(false);

            builder.Property(o => o.EnabledDate)
                .HasColumnName("enabled_date")
                .HasColumnType("date")
                .IsRequired(false);

            builder.Property(o => o.EnabledTime)
                .HasColumnName("enabled_time")
                .HasColumnType("time without time zone")
                .IsRequired(false);
        }
    }
}

