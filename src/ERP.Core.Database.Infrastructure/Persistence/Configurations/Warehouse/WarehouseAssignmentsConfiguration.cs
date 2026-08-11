using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class WarehouseAssignmentsConfiguration : IEntityTypeConfiguration<WarehouseAssignments>
{
    public void Configure(EntityTypeBuilder<WarehouseAssignments> builder)
    {
        builder.ToTable("warehouse_assignments");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();
        
        builder.Property(e => e.WarehouseId)
           .HasColumnName("warehouse_id")
           .IsRequired();
        
        builder.Property(e => e.SectionId)
            .HasColumnName("section_id")
            .IsRequired(false);
        
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
        builder.HasOne(x => x.RecordEntrance)
            .WithOne(x => x.Assignment)
            .HasForeignKey<WarehouseAssignments>(x => x.RecordEntranceId)
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

        builder.HasOne(x => x.Section)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.SectionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}