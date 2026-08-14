using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class UnloadingDetailsConfiguration : IEntityTypeConfiguration<UnloadingDetails>
{
    public void Configure(EntityTypeBuilder<UnloadingDetails> builder)
    {
        builder.ToTable("unloading_details");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("unloading_details_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();
            
        builder.Property(e => e.WarehouseAssignmentsId)
            .HasColumnName("warehouse_assignments_id")
            .IsRequired();
        
        builder.Property(e => e.UnloadingStartTime)
            .HasColumnName("unloading_start_time")
            .IsRequired();
        
        builder.Property(e => e.UnloadingEndTime)
            .HasColumnName("unloading_end_time")
            .IsRequired(false);
        
        builder.Property(e => e.WarehouseChiefUserId)
            .HasColumnName("warehouse_chief_user_id")
            .HasMaxLength(450)
            .IsRequired();
        
        builder.Property(e => e.PreparedPallets)
            .HasColumnName("prepared_pallets")
            .HasPrecision(10, 0)
            .IsRequired(false);
        
        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(e => e.RecordEntrance)
            .WithOne(e => e.UnloadingDetails)
            .HasForeignKey<UnloadingDetails>(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.WarehouseAssignments)
            .WithOne(e => e.UnloadingDetails)
            .HasForeignKey<UnloadingDetails>(e => e.WarehouseAssignmentsId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}