using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class UnloadingMachineryAssignmentsConfiguration : IEntityTypeConfiguration<UnloadingMachineryAssignments>
{
    public void Configure(EntityTypeBuilder<UnloadingMachineryAssignments> builder)
    {
        builder.ToTable("unloading_machinery_assignments");
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Id)
            .HasColumnName("unloading_machinery_assignment_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.UnloadingDetailsId)
            .HasColumnName("unloading_details_id")
            .IsRequired();
        
        builder.Property(x => x.MachineryCode)
            .HasColumnName("machinery_code")
            .IsRequired();

        builder.Property(x => x.StartTime)
            .HasColumnName("start_time")
            .IsRequired();

        builder.Property(x => x.EndTime)
            .HasColumnName("end_time")
            .IsRequired(false);

        builder.Property(x => x.AssignedByUserId)
            .HasColumnName("assigned_by_user_id")
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");


        // Relaciones
        builder.HasOne(x => x.UnloadingDetails)
            .WithMany(x => x.MachineryAssignments)
            .HasForeignKey(x => x.UnloadingDetailsId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Machinery)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.MachineryCode)
            .OnDelete(DeleteBehavior.Restrict);

    }
}