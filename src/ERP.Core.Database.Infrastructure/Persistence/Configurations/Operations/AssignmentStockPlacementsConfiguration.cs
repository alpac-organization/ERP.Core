using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations;

public class AssignmentStockPlacementsConfiguration : IEntityTypeConfiguration<AssignmentStockPlacements>
{
    public void Configure(EntityTypeBuilder<AssignmentStockPlacements> builder)
    {
        builder.ToTable("assignment_stock_placements");
            
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("assignment_stock_placement_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e. AssignmentId)
            .HasColumnName("assignment_id")
            .IsRequired();

        builder.Property(e => e.RackPositionId)
            .HasColumnName("rack_position_id")
            .IsRequired(false);

        builder.Property(e => e.LotPositionId)
            .HasColumnName("lot_position_id")
            .IsRequired(false);

        builder.Property(e => e.SectionId)
            .HasColumnName("section_id")
            .IsRequired(false);

        builder.Property(e => e.PlacedAt)
            .HasColumnName("placed_at")
            .IsRequired();

        builder.Property(e => e.PlacedByUserId)
            .HasColumnName("placed_by_user_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.AssignmentOperational)
            .WithMany(e => e.AssignmentStockPlacements)
            .HasForeignKey(e => e.AssignmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.RackPosition)
            .WithMany(x => x.AssignmentStockPlacements)
            .HasForeignKey(e => e.RackPositionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Section)
            .WithMany(x => x.AssignmentStockPlacements)
            .HasForeignKey(e => e.SectionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.LotPosition)
            .WithMany(x => x.AssignmentStockPlacements)
            .HasForeignKey(e => e.LotPositionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}