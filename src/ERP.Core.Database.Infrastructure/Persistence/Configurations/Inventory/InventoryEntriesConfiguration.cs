using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Inventory;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class InventoryEntriesConfiguration : IEntityTypeConfiguration<InventoryEntry>
    {
        public void Configure(EntityTypeBuilder<InventoryEntry> builder)
        {
            builder.ToTable("inventory_entries");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("inventory_entry_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(50);

            builder.Property(e => e.Observations)
                .HasColumnName("observations")
                .HasColumnType("text");

            builder.Property(e => e.EntryStatus)
                .HasColumnName("entry_status")
                .HasColumnType("entry_status_enum")
                .HasDefaultValueSql("'pending_review'::entry_status_enum")
                .HasSentinel(EntryStatus.PendingReview)
                .IsRequired();

            builder.Property(e => e.AdditionalData)
                .HasColumnName("additional_data")
                .HasColumnType("jsonb")
                .IsRequired(false);

            builder.Property(e => e.WorkAreaId)
                .HasColumnName("work_area_id")
                .IsRequired();

            builder.Property(e => e.BranchId)
                .HasColumnName("branch_id")
                .IsRequired();

            builder.Property(e => e.PurchaseRequestId)
                .HasColumnName("purchase_request_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            #region Foreign Keys

            builder.HasOne(e => e.WorkArea)
                .WithMany()
                .HasForeignKey(e => e.WorkAreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Branch)
                .WithMany()
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PurchaseRequest)
                .WithMany()
                .HasForeignKey(e => e.PurchaseRequestId)
                .OnDelete(DeleteBehavior.Restrict);
                
            #endregion

            #region Indexes

            builder.HasIndex(e => e.Code)
                .IsUnique()
                .HasDatabaseName("ux_inventory_entries_code");

            #endregion
        }
    }
}