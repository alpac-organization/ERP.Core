using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class WarehouseAssignmentsManaguaConfiguration : IEntityTypeConfiguration<WarehouseAssignmentsManagua>
{
    public void Configure(EntityTypeBuilder<WarehouseAssignmentsManagua> builder)
    {
        builder.ToTable("warehouse_assignments_managua");
        builder.HasKey(e => e.RecordEntranceManaguaId);
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_id")
            .ValueGeneratedNever();
        
        builder.Property(e => e.WarehouseId)
            .HasColumnName("warehouse_id")
            .IsRequired();
        
        builder.Property(e => e.ZoneId)
           .HasColumnName("zone_id");
        
        builder.Property(e => e.RackId)
            .HasColumnName("rack_id")
            .IsRequired();
        
        builder.Property(e => e.AssignedAt)
            .HasColumnName("assigned_at")
            .IsRequired();

        builder.HasOne(e => e.RecordEntranceManagua)
            .WithOne()
            .HasForeignKey<UnloadingDetailsManagua>(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}