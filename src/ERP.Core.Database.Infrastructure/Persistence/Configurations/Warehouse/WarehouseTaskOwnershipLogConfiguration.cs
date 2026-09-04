using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehouseTaskOwnershipLogConfiguration : IEntityTypeConfiguration<WarehouseTaskOwnershipLog>
{
    public void Configure(EntityTypeBuilder<WarehouseTaskOwnershipLog> builder)
    {
        builder.ToTable("warehouse_task_ownership_log");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("warehouse_task_ownership_log_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.WarehouseTaskId)
            .HasColumnName("warehouse_task_id")
            .IsRequired();

        builder.Property(e => e.PreviousOwnerUserId)
            .HasColumnName("previous_owner_user_id")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(e => e.NewOwnerUserId)
            .HasColumnName("new_owner_user_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.TransferredByUserId)
            .HasColumnName("transferred_by_user_id")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.TransferredAt)
            .HasColumnName("transferred_at")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
            
        builder.Property(e => e.DeletedAt).HasColumnName("deleted_at");

        builder.HasOne(e => e.WarehouseTask)
            .WithMany(t => t.OwnershipLogs)
            .HasForeignKey(e => e.WarehouseTaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.WarehouseTaskId, e.TransferredAt })
            .HasDatabaseName("ix_warehouse_task_ownership_log_task_transferred_at");
    }
}
