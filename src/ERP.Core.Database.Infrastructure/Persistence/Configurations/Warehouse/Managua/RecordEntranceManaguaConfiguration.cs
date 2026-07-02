using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class RecordEntranceManaguaConfiguration : IEntityTypeConfiguration<RecordEntranceManagua>
{
    public void Configure(EntityTypeBuilder<RecordEntranceManagua> builder)
    {
        builder.ToTable("record_entrances_managua");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("record_entrance_managua_id")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(e => e.ServiceOrderId)
            .HasColumnName("service_order_id")
            .IsRequired();

        builder.Property(e => e.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.Property(e => e.CurrentStepId)
            .HasColumnName("current_step_id")
            .IsRequired();

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.ClosedAt)
            .HasColumnName("closed_at")
            .IsRequired();

        builder.Property(e => e.IsConsolidated)
            .HasColumnName("is_consolidated")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        // Relaciones 1:1 y 1:N
        builder.HasOne(e => e.Warehouse)
            .WithMany()
            .HasForeignKey(d => d.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.CurrentStep)
            .WithMany(d => d.RecordEntrances)
            .HasForeignKey(d => d.CurrentStepId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}