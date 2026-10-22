

using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
   public class DisciplinaryFaultConfiguration : IEntityTypeConfiguration<DisciplinaryFault>
   {
      public void Configure(EntityTypeBuilder<DisciplinaryFault> builder)
      {
         builder.ToTable("disciplinary_faults");

         builder.HasKey(e => e.Id);

         builder.Property(e => e.Id)
            .HasColumnName("disciplinary_fault_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

         builder.HasIndex(e => e.Id)
            .IsUnique()
            .HasDatabaseName("ix_disciplinary_fault_id");

         builder.Property(e => e.CollaboratorId)
            .HasColumnName("collaborator_id")
            .IsRequired();

         builder.Property(e => e.FaultCatalogId)
            .HasColumnName("fault_catalog_id")
            .IsRequired();

         builder.Property(e => e.OccurrenceDate)
            .HasColumnName("occurrence_date")
            .HasColumnType("date")
            .IsRequired();

         builder.Property(e => e.Severity)
            .HasColumnName("severity")
            .HasColumnType("fault_severity_enum")
            .IsRequired();

         builder.Property(e => e.Source)
            .HasColumnName("source")
            .HasColumnType("fault_source_enum")
            .IsRequired();

         builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("fault_status_enum")
            .IsRequired();

         builder.Property(e => e.RegisteredBy)
            .HasColumnName("registered_by")
            .IsRequired();

         builder.Property(e => e.ParentFaultId)
            .HasColumnName("parent_fault_id")
            .IsRequired(false);

         builder.Property(e => e.Evidence)
            .HasColumnName("evidence")
            .HasColumnType("jsonb")
            .HasDefaultValue("{}")
            .IsRequired();

         builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

         builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

         builder.HasIndex(e => e.CollaboratorId)
            .HasDatabaseName("ix_disciplinary_faults_collaborator_id");

         builder.HasIndex(e => e.OccurrenceDate)
            .HasDatabaseName("ix_disciplinary_faults_occurrence_date");

         builder.HasOne(e => e.Collaborator)
            .WithMany(c => c.DisciplinaryFaults)
            .HasForeignKey(e => e.CollaboratorId)
            .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(e => e.FaultCatalog)
            .WithMany(c => c.DisciplinaryFaults)
            .HasForeignKey(e => e.FaultCatalogId)
            .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(e => e.User)
            .WithMany(c => c.DisciplinaryFaults)
            .HasForeignKey(e => e.RegisteredBy)
            .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(e => e.ParentFault)
            .WithMany()
            .HasForeignKey(e => e.ParentFaultId)
            .OnDelete(DeleteBehavior.Restrict);
      }
   }
}