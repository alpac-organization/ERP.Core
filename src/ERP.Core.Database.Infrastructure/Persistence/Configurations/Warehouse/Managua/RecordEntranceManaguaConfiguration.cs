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

        builder.Property(e => e.MovementNumber)
            .HasColumnName("movement_number")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.HasIndex(e => e.MovementNumber)
            .IsUnique();

        builder.Property(e => e.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();

        builder.Property(e => e.CurrentStepId)
            .HasColumnName("current_step_id")
            .HasDefaultValue(1);

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.ClosedAt)
            .HasColumnName("closed_at")
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // Relaciones 1:1 y 1:N
        builder.HasOne(e => e.ReceptionDetails)
            .WithOne(d => d.RecordEntrance)
            .HasForeignKey<ReceptionDetailsManagua>(d => d.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.EntranceDucats)
            .WithOne(d => d.RecordEntrance)
            .HasForeignKey(d => d.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}