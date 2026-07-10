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

        builder.Property(e => e.Id)
            .HasColumnName("unloading_crew_assignment_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
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

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.Property(x => x.Id)
            .HasColumnName("unloading_details_managua_id")
            .IsRequired();

        builder.HasOne(x => x.UnloadingDetails)
            .WithMany(x => x.CrewAssignments)
            .HasForeignKey(x => x.UnloadingDetailsManaguaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}