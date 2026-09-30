using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations;

public class AssignmentCollaboratorsConfiguration : IEntityTypeConfiguration<AssignmentCollaborators>
{
    public void Configure(EntityTypeBuilder<AssignmentCollaborators> builder)
    {
        builder.ToTable("assignment_collaborators");

        builder.HasKey(ac => ac.Id);

        builder.Property(ac => ac.Id)
            .HasColumnName("assignment_collaborator_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(ac => ac.AssignmentOperationalId)
            .HasColumnName("assignment_operational_id")
            .IsRequired();

        builder.Property(ac => ac.CollaboratorId)
            .HasColumnName("collaborator_id")
            .IsRequired();

        builder.Property(ac => ac.Role)
            .HasColumnName("role")
            .HasColumnType("assignment_collaborators_roles_enum")
            .IsRequired();

        builder.Property(ac => ac.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(ac => ac.AssignmentOperational)
            .WithMany(ao => ao.AssignmentCollaborators)
            .HasForeignKey(ac => ac.AssignmentOperationalId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ac => ac.User)
            .WithMany(u => u.AssignmentCollaborators)
            .HasForeignKey(ac => ac.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ac => ac.Collaborator)
            .WithMany()
            .HasForeignKey(ac => ac.CollaboratorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(ac => ac.AssignmentOperationalId)
            .HasDatabaseName("ix_assignment_collaborators_assignment_operational_id");

        builder.HasIndex(ac => ac.CollaboratorId)
            .HasDatabaseName("ix_assignment_collaborators_collaborator_id");
    }
}