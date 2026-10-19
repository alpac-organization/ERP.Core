using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Inventory;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Inventory
{
    public class SupplyRequestConfiguration : IEntityTypeConfiguration<SupplyRequest>
    {
        public void Configure(EntityTypeBuilder<SupplyRequest> builder)
        {
            builder.ToTable("supply_requests");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("supply_request_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(50);

            builder.Property(e => e.Justification)
                .HasColumnName("justification")
                .HasColumnType("text");

            builder.Property(e => e.OutflowStatus)
                .HasColumnName("outflow_status")
                .HasColumnType("outflow_status_enum")
                .HasDefaultValueSql("'pending_review'::outflow_status_enum")
                .HasSentinel(OutflowStatus.PendingReview)
                .IsRequired();

            builder.Property(e => e.WorkAreaId)
                .HasColumnName("work_area_id")
                .IsRequired();

            builder.Property(e => e.CostCenterId)
                .HasColumnName("cost_center_id")
                .IsRequired();

            builder.Property(e => e.BranchId)
                .HasColumnName("branch_id")
                .IsRequired();

            builder.Property(e => e.WarehouseId)
                .HasColumnName("warehouse_id")
                .IsRequired();

            builder.Property(e => e.OperationalOrderId)
                .HasColumnName("operational_order_id")
                .IsRequired();

            builder.Property(e => e.RequestedByUserId)
                .HasColumnName("requested_by_user_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .IsRequired(false);

            #region Foreign Keys
            
            builder.HasOne(e => e.WorkArea)
                .WithMany(e => e.SupplyRequests)
                .HasForeignKey(e => e.WorkAreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CostCenter)
                .WithMany(e => e.SupplyRequests)
                .HasForeignKey(e => e.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Branch)
                .WithMany(e => e.SupplyRequests)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Warehouse)
                .WithMany(e => e.SupplyRequests)
                .HasForeignKey(e => e.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.OperationalOrder)
                .WithMany(e => e.SupplyRequests)
                .HasForeignKey(e => e.OperationalOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.User)
                .WithMany(e => e.SupplyRequests)
                .HasForeignKey(e => e.RequestedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Indexes

            builder.HasIndex(e => e.Code)
                .IsUnique()
                .HasDatabaseName("ux_supply_requests_code")
                .HasFilter("\"deleted_at\" IS NULL");

            #endregion
        }
    }
}