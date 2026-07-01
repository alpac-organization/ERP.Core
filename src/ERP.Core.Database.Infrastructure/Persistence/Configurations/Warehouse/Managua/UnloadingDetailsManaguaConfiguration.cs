using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class UnloadingDetailsManaguaConfiguration : IEntityTypeConfiguration<UnloadingDetailsManagua>
{
    public void Configure(EntityTypeBuilder<UnloadingDetailsManagua> builder)
    {
        builder.ToTable("unloading_details_managua");
        builder.HasKey(e => e.RecordEntranceManaguaId);
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_id")
            .ValueGeneratedNever();
        
        builder.Property(e => e.UnloadingStartTime)
            .HasColumnName("unloading_start_time")
            .IsRequired();
            
        builder.Property(e => e.UnloadingEndTime)
            .HasColumnName("unloading_end_time");
        
        builder.Property(e => e.WarehouseChiefUserId)
            .HasColumnName("warehouse_chief_user_id")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.PreparedPalletsPerHour)
            .HasColumnName("prepared_pallets_per_hour")
            .HasPrecision(5, 2);

        builder.HasOne(e => e.RecordEntranceManagua)
            .WithOne()
            .HasForeignKey<UnloadingDetailsManagua>(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}