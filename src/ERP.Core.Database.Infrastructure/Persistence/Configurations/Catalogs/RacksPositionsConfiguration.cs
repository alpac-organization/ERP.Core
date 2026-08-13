using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Catalogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

public class RackPositionsConfiguration : IEntityTypeConfiguration<RackPositions>
{
    public void Configure(EntityTypeBuilder<RackPositions> builder)
    {
        builder.ToTable("rack_positions");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("rack_position_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.RackId)
            .HasColumnName("rack_id")
            .IsRequired();

        builder.Property(e => e.PositionNumber)
            .HasColumnName("position_number")
            .IsRequired();

        builder.Property(e => e.PositionCode)
            .HasColumnName("position_code")
            .HasMaxLength(50)
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

        builder.HasIndex(e => e.RackId)
            .HasDatabaseName("ix_rack_positions_rack_id");

        builder.HasOne(e => e.Rack)
            .WithMany(r => r.Positions)
            .HasForeignKey(e => e.RackId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.RackId, e.PositionNumber })
            .IsUnique()
            .HasDatabaseName("ix_rack_positions_rack_id_position_number");

        builder.HasIndex(e => new { e.RackId, e.PositionCode })
            .IsUnique()
            .HasDatabaseName("ix_rack_positions_rack_id_position_code");
    }
}