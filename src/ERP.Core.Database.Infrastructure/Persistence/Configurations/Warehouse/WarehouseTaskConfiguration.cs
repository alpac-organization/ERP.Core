using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehouseTaskConfiguration : IEntityTypeConfiguration<WarehouseTask>
{
    public void Configure(EntityTypeBuilder<WarehouseTask> builder)
    {
        builder.ToTable("warehouse_tasks");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("warehouse_task_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.Property(e => e.TaskType)
            .HasColumnName("task_type")
            .HasColumnType("warehouse_task_type_enum")
            .IsRequired();

        builder.Property(e => e.SourceId)
            .HasColumnName("source_id")
            .IsRequired();

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("warehouse_task_status_enum")
            .HasDefaultValue(WarehouseTaskStatus.InProgress)
            .IsRequired();

        builder.Property(e => e.CurrentOwnerUserId)
            .HasColumnName("current_owner_user_id")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(e => e.CreatedByUserId)
            .HasColumnName("created_by_user_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.StartedAt)
            .HasColumnName("started_at")
            .IsRequired(false);

        builder.Property(e => e.PausedAt)
            .HasColumnName("paused_at")
            .IsRequired(false);

        builder.Property(e => e.CompletedAt)
            .HasColumnName("completed_at")
            .IsRequired(false);

        builder.Property(e => e.CancelledAt)
            .HasColumnName("cancelled_at")
            .IsRequired(false);

        builder.Property(e => e.ClosedAt)
            .HasColumnName("closed_at")
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.Warehouse)
            .WithMany()
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.WarehouseId, e.Status })
            .HasDatabaseName("ix_warehouse_tasks_company_warehouse_status");

        builder.HasIndex(e => new { e.TaskType, e.SourceId })
            .IsUnique()
            .HasDatabaseName("ux_warehouse_tasks_type_source");
    }
}
