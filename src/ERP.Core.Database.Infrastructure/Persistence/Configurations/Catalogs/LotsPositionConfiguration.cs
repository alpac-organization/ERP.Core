using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class TramoPositionsConfiguration : IEntityTypeConfiguration<LotsPositions>
{
    public void Configure(EntityTypeBuilder<LotsPositions> builder)
    {
        builder.ToTable("tramo_positions");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("tramo_position_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.LotId)
            .HasColumnName("tramo_id")
            .IsRequired();

        builder.Property(e => e.RowNumber)
            .HasColumnName("row_number")
            .IsRequired();

        builder.Property(e => e.ColumnNumber)
            .HasColumnName("column_number")
            .IsRequired();

        builder.Property(e => e.PositionCode)
            .HasColumnName("position_code")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.AllowsStacking)
            .HasColumnName("allows_stacking")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.IsOccupied)
            .HasColumnName("is_occupied")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.IsBlocked)
            .HasColumnName("is_blocked")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.BlockReason)
            .HasColumnName("block_reason")
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasIndex(e => new { e.LotId, e.PositionCode })
            .IsUnique()
            .HasDatabaseName("ix_tramo_positions_tramo_id_position_code");

        builder.HasIndex(e => e.LotId)
            .HasDatabaseName("ix_tramo_positions_tramo_id");

        builder.HasOne(e => e.Lot)
            .WithMany(t => t.Positions)
            .HasForeignKey(e => e.LotId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}