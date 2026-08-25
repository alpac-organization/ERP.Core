using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class StockPlacementsConfiguration : IEntityTypeConfiguration<StockPlacements>
{
    public void Configure(EntityTypeBuilder<StockPlacements> builder)
    {
        builder.ToTable("stock_placements", t =>
            t.HasCheckConstraint(
                "ck_stock_placements_exactly_one_position",
                "(rack_position_id IS NOT NULL AND lot_position_id IS NULL) OR (rack_position_id IS NULL AND lot_position_id IS NOT NULL)"));

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("stock_placement_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.StockId)
            .HasColumnName("stock_id")
            .IsRequired();

        builder.Property(e => e.RackPositionId)
            .HasColumnName("rack_position_id")
            .IsRequired(false);

        builder.Property(e => e.LotPositionId)
            .HasColumnName("lot_position_id")
            .IsRequired(false);

        builder.Property(e => e.PlacedAtDate)
            .HasColumnName("placed_at_date")
            .HasColumnType("date")
            .IsRequired();

        builder.Property(e => e.PlacedAtTime)
            .HasColumnName("placed_at_time")
            .IsRequired();

        builder.Property(e => e.PlacedByUserId)
            .HasColumnName("placed_by_user_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.VacatedAtDate)
            .HasColumnName("vacated_at_date")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(e => e.VacatedAtTime)
            .HasColumnName("vacated_at_time")
            .IsRequired(false);

        builder.Property(e => e.VacatedByUserId)
            .HasColumnName("vacated_by_user_id")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(e => e.PlacedByMemoryItemId)
            .HasColumnName("placed_by_memory_item_id")
            .IsRequired(false);

        builder.Property(e => e.VacatedByMemoryItemId)
            .HasColumnName("vacated_by_memory_item_id")
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.Stock)
            .WithMany()
            .HasForeignKey(e => e.StockId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.RackPosition)
            .WithMany()
            .HasForeignKey(e => e.RackPositionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.LotPosition)
            .WithMany()
            .HasForeignKey(e => e.LotPositionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.PlacedByMemoryItem)
            .WithMany(m => m.DestinationPlacements)
            .HasForeignKey(e => e.PlacedByMemoryItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.VacatedByMemoryItem)
            .WithMany(m => m.OriginPlacements)
            .HasForeignKey(e => e.VacatedByMemoryItemId)
            .OnDelete(DeleteBehavior.Restrict);

        // Disponibilidad en tiempo real: consultas filtran por VacatedAt IS NULL
        builder.HasIndex(e => e.RackPositionId)
            .HasDatabaseName("ix_stock_placements_rack_position_id");

        builder.HasIndex(e => e.LotPositionId)
            .HasDatabaseName("ix_stock_placements_lot_position_id");

        builder.HasIndex(e => e.StockId)
            .HasDatabaseName("ix_stock_placements_stock_id");

        builder.HasIndex(e => e.VacatedAtDate)
            .HasDatabaseName("ix_stock_placements_vacated_at_date");

        builder.HasIndex(e => e.VacatedAtTime)
            .HasDatabaseName("ix_stock_placements_vacated_at_time");
    }
}