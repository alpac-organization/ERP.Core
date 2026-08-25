using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class StockMovementEventsConfiguration : IEntityTypeConfiguration<StockMovementEvents>
{
    public void Configure(EntityTypeBuilder<StockMovementEvents> builder)
    {
        builder.ToTable("stock_movement_events");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("stock_movement_event_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.ReassignmentSessionId)
            .HasColumnName("reassignment_session_id")
            .IsRequired();

        builder.Property(e => e.ReassignmentMemoryItemId)
            .HasColumnName("reassignment_memory_item_id")
            .IsRequired();

        builder.Property(e => e.StockId)
            .HasColumnName("stock_id")
            .IsRequired();

        builder.Property(e => e.ConfirmedAtDate)
            .HasColumnName("confirmed_at_date")
            .HasColumnType("date")
            .IsRequired();

        builder.Property(e => e.ConfirmedAtTime)
            .HasColumnName("confirmed_at_time")
            .IsRequired();

        builder.Property(e => e.ConfirmedByUserId)
            .HasColumnName("confirmed_by_user_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.Session)
            .WithMany()
            .HasForeignKey(e => e.ReassignmentSessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.MemoryItem)
            .WithMany()
            .HasForeignKey(e => e.ReassignmentMemoryItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Stock)
            .WithMany()
            .HasForeignKey(e => e.StockId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.ReassignmentSessionId)
            .HasDatabaseName("ix_stock_movement_events_session_id");

        builder.HasIndex(e => e.StockId)
            .HasDatabaseName("ix_stock_movement_events_stock_id");

        // Trazabilidad: reconstruir historial completo de un stock, ordenado
        builder.HasIndex(e => new { e.StockId, e.ConfirmedAtDate, e.ConfirmedAtTime })
            .HasDatabaseName("ix_stock_movement_events_stock_id_confirmed_at");
    }
}