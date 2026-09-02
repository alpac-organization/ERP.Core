using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class MachineryAssignmentsConfiguration : IEntityTypeConfiguration<MachineryAssignments>
{
    public void Configure(EntityTypeBuilder<MachineryAssignments> builder)
    {
        builder.ToTable("machinery_assignments");
        
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.WarehouseAssignmentId)
            .HasColumnName("warehouse_assignment_id")
            .IsRequired();

        builder.Property(x => x.MachineryId)
            .HasColumnName("machinery_id")
            .IsRequired(false);

        builder.Property(x => x.OperatorCollaboratorId)
            .HasColumnName("operator_collaborator_id")
            .IsRequired(false);

        builder.Property(x => x.IsOutsourced)
            .HasColumnName("is_outsourced")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.ProviderName)
            .HasColumnName("provider_name")
            .HasMaxLength(150)
            .IsRequired(false);

        builder.Property(x => x.InvoiceNumber)
            .HasColumnName("invoice_number")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(x => x.MachineryDescription)
            .HasColumnName("machinery_description")
            .HasMaxLength(250)
            .IsRequired(false);

        builder.Property(x => x.StartTime)
            .HasColumnName("start_time")
            .IsRequired();

        builder.Property(x => x.EndTime)
            .HasColumnName("end_time")
            .IsRequired(false);

        builder.Property(x => x.AssignedByUserId)
            .HasColumnName("assigned_by_user_id")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        // Relaciones
        builder.HasOne(x => x.WarehouseAssignment)
            .WithMany(x => x.MachineryAssignments)
            .HasForeignKey(x => x.WarehouseAssignmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Machinery)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.MachineryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
