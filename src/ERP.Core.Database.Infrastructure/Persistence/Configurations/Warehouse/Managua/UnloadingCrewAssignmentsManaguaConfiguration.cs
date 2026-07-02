using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class UnloadingCrewAssignmentsManaguaConfiguration : IEntityTypeConfiguration<UnloadingCrewAssignmentsManagua>
{
    public void Configure(EntityTypeBuilder<UnloadingCrewAssignmentsManagua> builder)
    {
        builder.ToTable("unloading_crew_assignments_managua");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UnloadingDetailsManaguaId)
            .HasColumnName("unloading_details_managua_id")
            .IsRequired();

        builder.Property(x => x.AssignedAt)
            .HasColumnName("assigned_at")
            .IsRequired();

        builder.Property(x => x.PersonaCount)
            .HasColumnName("persona_count")
            .IsRequired();

        builder.Property(x => x.Tecerizada)
            .HasColumnName("tercerizada")
            .IsRequired();

        builder.HasOne(x => x.UnloadingDetails)
            .WithMany(x => x.CrewAssignments)
            .HasForeignKey(x => x.UnloadingDetailsManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}