using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class UnloadingMachineryAssignmentsManaguaConfiguration : IEntityTypeConfiguration<UnloadingMachineryAssignmentsManagua>
{
    public void Configure(EntityTypeBuilder<UnloadingMachineryAssignmentsManagua> builder)
    {
        builder.ToTable("UnloadingMachineryAssignmentsManagua");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(x => x.UnloadingDetailsManaguaId)
            .HasColumnName("unloading_details_managua_id")
            .IsRequired();
        
        builder.Property(x => x.MachineryCode)
            .HasColumnName("machinery_code")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.MachineryType)
            .HasColumnName("machinery_type")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.StartTime)
            .HasColumnName("start_time")
            .IsRequired();

        builder.Property(x => x.EndTime)
            .HasColumnName("end_time")
            .IsRequired();

        builder.Property(x => x.AssignedByUserId)
            .HasColumnName("assigned_by_user_id")
            .HasMaxLength(450)
            .IsRequired();

        // Relación
        builder.HasOne(x => x.UnloadingDetailsManagua)
            .WithMany(x => x.MachineryAssignments)
            .HasForeignKey(x => x.UnloadingDetailsManaguaId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}