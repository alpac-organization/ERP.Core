using ERP.Core.Database.Domain.Entities.Inventory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class ReasonsInventoryRemovalConfiguration : IEntityTypeConfiguration<ReasonsInventoryRemoval>
    {
        public void Configure(EntityTypeBuilder<ReasonsInventoryRemoval> builder)
        {
            builder.ToTable("reasons_inventory_removals");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("reason_inventory_removal_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("text");

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasIndex(e => e.Code)
                .IsUnique()
                .HasDatabaseName("ux_reasons_inventory_removals_code")
                .HasFilter("\"deleted_at\" IS NULL");
        }
    }
}