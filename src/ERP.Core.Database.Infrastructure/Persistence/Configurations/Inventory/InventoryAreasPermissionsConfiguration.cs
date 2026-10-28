using ERP.Core.Database.Domain.Entities.Inventory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class InventoryAreasPermissionsConfiguration : IEntityTypeConfiguration<InventoryAreasPermissions>
    {
        public void Configure(EntityTypeBuilder<InventoryAreasPermissions> builder)
        {
            builder.ToTable("inventory_areas_permissions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("inventory_areas_permission_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.WorkAreaId)
                .HasColumnName("work_area_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("timestamp with time zone");

            builder.HasIndex(e => e.WorkAreaId)
                .HasDatabaseName("ix_inventory_areas_permissions_work_area_id");
                
            builder.HasOne(e => e.WorkArea)
                .WithMany(e => e.InventoryAreasPermissions)
                .HasForeignKey(e => e.WorkAreaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}