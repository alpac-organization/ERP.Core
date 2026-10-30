using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class InventoryOutputsConfiguration : IEntityTypeConfiguration<InventoryOutputs>
    {
        public void Configure(EntityTypeBuilder<InventoryOutputs> builder)
        {
            builder.ToTable("inventory_outputs");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("inventory_output_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Observations)
                .HasColumnName("observations")
                .IsRequired(false);

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("inventory_outputs_status_enum")
                .HasDefaultValueSql("'output_pending'::inventory_outputs_status_enum")
                .IsRequired();

            builder.Property(e => e.BranchId)
                .HasColumnName("branch_id")
                .IsRequired();

            builder.Property(e => e.WorkAreaId)
                .HasColumnName("work_area_id")
                .IsRequired();

            builder.Property(e => e.CostCenterId)
                .HasColumnName("cost_center_id")
                .IsRequired();

            builder.Property(e => e.SupplyRequestId)
                .HasColumnName("supply_request_id")
                .IsRequired();

            builder.Property(e => e.ReasonsInventoryRemovalId)
                .HasColumnName("reason_inventory_removal_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");


            #region Foreign Keys

            builder.HasOne(e => e.Branch)
                .WithMany(e => e.InventoryOutputs)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.WorkArea)
                .WithMany(e => e.InventoryOutputs)
                .HasForeignKey(e => e.WorkAreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CostCenter)
                .WithMany(e => e.InventoryOutputs)
                .HasForeignKey(e => e.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SupplyRequest)
                .WithOne(e => e.InventoryOutput)
                .HasForeignKey<InventoryOutputs>(e => e.SupplyRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ReasonsInventoryRemoval)
                .WithMany()
                .HasForeignKey(e => e.ReasonsInventoryRemovalId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Foreign Keys

        }
    }
}