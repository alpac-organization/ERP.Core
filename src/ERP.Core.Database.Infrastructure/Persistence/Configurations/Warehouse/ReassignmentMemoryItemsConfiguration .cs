using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class ReassignmentMemoryItemsConfiguration : IEntityTypeConfiguration<ReassignmentMemoryItems>
{
    public void Configure(EntityTypeBuilder<ReassignmentMemoryItems> builder)
    {
        builder.ToTable("reassignment_memory_items");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("reassignment_memory_item_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.ReassignmentSessionId)
            .HasColumnName("reassignment_session_id")
            .IsRequired();

        builder.Property(e => e.StockId)
            .HasColumnName("stock_id")
            .IsRequired();

        builder.Property(e => e.LiftedAtDate)
            .HasColumnName("lifted_at_date")
            .HasColumnType("date")
            .IsRequired();

        builder.Property(e => e.LiftedAtTime)
            .HasColumnName("lifted_at_time")
            .IsRequired();

        builder.Property(e => e.LiftedByUserId)
            .HasColumnName("lifted_by_user_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.ResolvedAtDate)
            .HasColumnName("resolved_at_date")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(e => e.ResolvedAtTime)
            .HasColumnName("resolved_at_time")
            .IsRequired(false);

        builder.Property(e => e.ResolvedByUserId)
            .HasColumnName("resolved_by_user_id")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.Session)
            .WithMany(s => s.MemoryItems)
            .HasForeignKey(e => e.ReassignmentSessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Stock)
            .WithMany()
            .HasForeignKey(e => e.StockId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.ReassignmentSessionId)
            .HasDatabaseName("ix_reassignment_memory_items_session_id");

        // Consulta clave: pendientes de una sesion (ResolvedAt IS NULL)
        builder.HasIndex(e => new { e.ReassignmentSessionId, e.ResolvedAtDate, e.ResolvedAtTime })
            .HasDatabaseName("ix_reassignment_memory_items_session_resolved_at");

        builder.HasIndex(e => e.StockId)
            .HasDatabaseName("ix_reassignment_memory_items_stock_id");
    }
}