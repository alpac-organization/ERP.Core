using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class WarehouseAssignmentsManaguaConfiguration : IEntityTypeConfiguration<WarehouseAssignmentsManagua>
{
    public void Configure(EntityTypeBuilder<WarehouseAssignmentsManagua> builder)
    {
        builder.ToTable("warehouse_assignments_managua");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_managua_id")
            .IsRequired();
        
        builder.Property(e => e.WarehouseId)
           .HasColumnName("warehouse_id")
           .IsRequired();
        
        builder.Property(e => e.ZoneId)
            .HasColumnName("zone_id")
            .IsRequired();
        
        builder.Property(e => e.RackId)
            .HasColumnName("rack_id")
            .IsRequired();
        
        builder.Property(e => e.AssignedAt)
            .HasColumnName("assigned_at")
            .IsRequired();
        
        builder.Property(e => e.AssignedByUserId)
            .HasColumnName("assigned_by_user_id")
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");


        // Relación 1:1 con la entrada principal
        builder.HasOne(x => x.RecordEntranceManagua)
            .WithOne(x => x.Assignment)
            .HasForeignKey<WarehouseAssignmentsManagua>(x => x.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relaciones con los catálogos del layout regional
        builder.HasOne(x => x.Warehouse)
            .WithMany()
            .HasForeignKey(x => x.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Rack)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.RackId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Zone)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.ZoneId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}