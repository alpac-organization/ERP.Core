using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class CrewAssignmentsConfiguration : IEntityTypeConfiguration<CrewAssignments>
{
    public void Configure(EntityTypeBuilder<CrewAssignments> builder)
    {
        builder.ToTable("crew_assignments");
        
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.AssignedAt)
            .HasColumnName("assigned_at")
            .IsRequired();

        builder.Property(x => x.CollaboratorId)
            .HasColumnName("collaborator_id")
            .IsRequired(false);

        builder.Property(x => x.IsOutsourced)
            .HasColumnName("is_outsourced")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.PersonCount)
            .HasColumnName("person_count")
            .IsRequired(false);

        builder.Property(x => x.ProviderName)
            .HasColumnName("provider_name")
            .HasMaxLength(150)
            .IsRequired(false);

        builder.Property(x => x.InvoiceNumber)
            .HasColumnName("invoice_number")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(x => x.WarehouseAssignmentId)
            .HasColumnName("warehouse_assignment_id")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(x => x.WarehouseAssignment)
            .WithMany(x => x.CrewAssignments)
            .HasForeignKey(x => x.WarehouseAssignmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
