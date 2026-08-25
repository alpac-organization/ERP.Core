using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class ReassignmentSessionsConfiguration : IEntityTypeConfiguration<ReassignmentSessions>
{
    public void Configure(EntityTypeBuilder<ReassignmentSessions> builder)
    {
        builder.ToTable("reassignment_sessions");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("reassignment_session_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("reassignment_session_status_enum")
            .HasDefaultValue(ReassignmentSessionStatus.Open)
            .IsRequired();

        builder.Property(e => e.CurrentOwnerUserId)
            .HasColumnName("current_owner_user_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.OpenedAtDate)
            .HasColumnName("opened_at_date")
            .HasColumnType("date")
            .IsRequired();

        builder.Property(e => e.OpenedAtTime)
            .HasColumnName("opened_at_Time")
            .IsRequired();

        builder.Property(e => e.OpenedByUserId)
            .HasColumnName("opened_by_user_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.ClosedAtDate)
            .HasColumnName("closed_at_date")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(e => e.ClosedAtTime)
            .HasColumnName("closed_at_time")
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

        builder.HasIndex(e => e.WarehouseId)
            .HasDatabaseName("ix_reassignment_sessions_warehouse_id");

        builder.HasIndex(e => e.Status)
            .HasDatabaseName("ix_reassignment_sessions_status");
    }
}