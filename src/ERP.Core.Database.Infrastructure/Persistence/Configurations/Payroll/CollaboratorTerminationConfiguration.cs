using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
   public class CollaboratorTerminationConfiguration : IEntityTypeConfiguration<CollaboratorTermination>
   {
      public void Configure(EntityTypeBuilder<CollaboratorTermination> builder)
      {
         builder.ToTable("collaborator_terminations");

         builder.HasKey(ct => ct.Id);

         builder.Property(ct => ct.Id)
            .HasColumnName("termination_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

         builder.HasIndex(ct => ct.Id)
            .IsUnique()
            .HasDatabaseName("ix_collaborator_termination_id");

         builder.Property(ct => ct.CollaboratorId)
            .HasColumnName("collaborator_id")
            .IsRequired();

         builder.Property(ct => ct.SanctionId)
            .HasColumnName("sanction_id")
            .IsRequired(false);

         builder.Property(ct => ct.DepartureDate)
            .HasColumnName("departure_date")
            .HasColumnType("date")
            .IsRequired();

         builder.Property(ct => ct.NoticeDate)
            .HasColumnName("notice_date")
            .HasColumnType("date")
            .IsRequired(false);

         builder.Property(ct => ct.NoticeDays)
            .HasColumnName("notice_days")
            .IsRequired(false);

         builder.Property(ct => ct.TerminationType)
            .HasColumnName("termination_type")
            .HasColumnType("termination_type_enum")
            .IsRequired();

         builder.Property(ct => ct.TerminationStatus)
            .HasColumnName("termination_status")
            .HasColumnType("termination_status_enum")
            .IsRequired();

         builder.Property(ct => ct.Reason)
            .HasColumnName("reason")
            .HasMaxLength(500)
            .IsRequired();

         builder.Property(ct => ct.CancellationReason)
            .HasColumnName("cancellation_reason")
            .HasMaxLength(500)
            .IsRequired(false);

         builder.Property(ct => ct.RegisteredBy)
            .HasColumnName("registered_by")
            .IsRequired();

         builder.Property(ct => ct.ClosedBy)
            .HasColumnName("closed_by")
            .IsRequired(false);

         builder.Property(ct => ct.ClosedAt)
            .HasColumnName("closed_at")
            .IsRequired(false);

         builder.Property(ct => ct.Evidence)
            .HasColumnName("evidence")
            .HasColumnType("jsonb")
            .HasDefaultValue("{}")
            .IsRequired();

         builder.Property(ct => ct.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

         builder.Property(ct => ct.DeletedAt)
            .HasColumnName("deleted_at");

         builder.HasIndex(ct => ct.CollaboratorId)
            .HasDatabaseName("ix_collaborator_terminations_collaborator_id");

         builder.HasIndex(ct => ct.RegisteredBy)
            .HasDatabaseName("ix_collaborator_terminations_registered_by");

         builder.HasIndex(ct => ct.ClosedBy)
            .HasDatabaseName("ix_collaborator_terminations_closed_by");
         
         builder.HasIndex(ct => ct.CollaboratorId)
            .IsUnique()
            .HasFilter("termination_status = 'pending' AND deleted_at IS NULL")
            .HasDatabaseName("ix_collaborator_terminations_collaborator_id_pending");

         builder.HasIndex(ct => ct.SanctionId)
            .IsUnique()
            .HasFilter("sanction_id IS NOT NULL")
            .HasDatabaseName("ix_collaborator_terminations_sanction_id");

         builder.HasOne(ct => ct.Collaborator)
            .WithMany(c => c.Terminations)
            .HasForeignKey(ct => ct.CollaboratorId)
            .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(ct => ct.DisciplinarySanction)
            .WithOne(s => s.Termination)
            .HasForeignKey<CollaboratorTermination>(ct => ct.SanctionId)
            .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(ct => ct.RegisteredByUser)
            .WithMany()
            .HasForeignKey(ct => ct.RegisteredBy)
            .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(ct => ct.ClosedByUser)
            .WithMany()
            .HasForeignKey(ct => ct.ClosedBy)
            .OnDelete(DeleteBehavior.Restrict);
      }
   }
}
