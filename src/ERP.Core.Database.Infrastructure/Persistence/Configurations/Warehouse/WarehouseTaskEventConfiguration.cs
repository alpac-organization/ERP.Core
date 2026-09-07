using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehouseTaskEventConfiguration : IEntityTypeConfiguration<WarehouseTaskEvent>
{
    public void Configure(EntityTypeBuilder<WarehouseTaskEvent> builder)
    {
        builder.ToTable("warehouse_task_events");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("warehouse_task_event_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.WarehouseTaskId)
            .HasColumnName("warehouse_task_id")
            .IsRequired();

        builder.Property(e => e.EventType)
            .HasColumnName("event_type")
            .HasColumnType("warehouse_task_event_type_enum")
            .IsRequired();

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("warehouse_task_status_enum")
            .IsRequired(false);

        builder.Property(e => e.UserId)
            .HasColumnName("user_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.OccurredAt)
            .HasColumnName("occurred_at")
            .IsRequired();

        builder.Property(e => e.Notes)
            .HasColumnName("notes")
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.WarehouseTask)
            .WithMany(t => t.Events)
            .HasForeignKey(e => e.WarehouseTaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.WarehouseTaskId, e.OccurredAt })
            .HasDatabaseName("ix_warehouse_task_events_task_occurred_at");
    }
}
