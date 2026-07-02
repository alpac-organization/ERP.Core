using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class UnloadingDetailsManaguaConfiguration : IEntityTypeConfiguration<UnloadingDetailsManagua>
{
    public void Configure(EntityTypeBuilder<UnloadingDetailsManagua> builder)
    {
        builder.ToTable("unloading_details_managua");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("unloading_details_managua_id")
            .IsRequired();
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_managua_id")
            .IsRequired();
            
        builder.Property(e => e.WarehouseAssignmentsManaguaId)
            .HasColumnName("warehouse_assignments_managua_id")
            .IsRequired();
        
        builder.Property(e => e.UnloadingStartTime)
            .HasColumnName("unloading_start_time")
            .IsRequired();
        
        builder.Property(e => e.UnloadingEndTime)
            .HasColumnName("unloading_end_time")
            .IsRequired();
        
        builder.Property(e => e.WarehouseChiefUserId)
            .HasColumnName("warehouse_chief_user_id")
            .HasMaxLength(450)
            .IsRequired();
        
        builder.Property(e => e.PreparedPallets)
            .HasColumnName("prepared_pallets")
            .HasPrecision(2, 0)
            .IsRequired();
        
        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");



        builder.HasOne(e => e.RecordEntranceManagua)
            .WithOne(e => e.UnloadingDetails)
            .HasForeignKey<UnloadingDetailsManagua>(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.WarehouseAssignmentsManagua)
            .WithOne(e => e.UnloadingDetails)
            .HasForeignKey<UnloadingDetailsManagua>(e => e.WarehouseAssignmentsManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}