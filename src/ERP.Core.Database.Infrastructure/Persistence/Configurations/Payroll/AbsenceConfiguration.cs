using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
   public class AbsenceConfiguration : IEntityTypeConfiguration<Absence>
   {
      public void Configure(EntityTypeBuilder<Absence> builder)
      {
         builder.ToTable("absences");

         builder.HasKey(e => e.Id);

         builder.Property(e => e.Id)
            .HasColumnName("absence_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

         builder.HasIndex(e => e.Id)
            .IsUnique()
            .HasDatabaseName("ix_absence_id");

         builder.Property(e => e.CollaboratorId)
            .HasColumnName("collaborator_id")
            .IsRequired();

         builder.Property(e => e.Date)
            .HasColumnName("date")
            .HasColumnType("date")
            .IsRequired();

         builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("absence_status_enum")
            .HasDefaultValue(AbsenceStatus.Pending)
            .IsRequired();

         builder.Property(e => e.Source)
            .HasColumnName("source")
            .HasColumnType("absence_source_enum")
            .HasDefaultValue(AbsenceSource.BiometricClock)
            .IsRequired();

         builder.Property(e => e.Reason)
            .HasColumnName("reason")
            .HasMaxLength(500)
            .IsRequired(false);
            
         builder.Property(e => e.RegisteredBy)
            .HasColumnName("registered_by")
            .IsRequired();

         builder.Property(e => e.ReviewedBy)
            .HasColumnName("reviewed_by")
            .IsRequired(false);

         builder.Property(e => e.ReviewedAt)
            .HasColumnName("reviewed_at")
            .IsRequired(false);

         builder.Property(e => e.CancellationReason)
            .HasColumnName("cancellation_reason")
            .HasMaxLength(500)
            .IsRequired(false);

         builder.Property(e => e.SalaryDeduction)
            .HasColumnName("salary_deduction")
            .HasPrecision(18, 2)
            .HasDefaultValue(0.0m)
            .IsRequired();

         builder.Property(e => e.SeventhDayDeduction)
            .HasColumnName("seventh_day_deduction")
            .HasPrecision(18, 2)
            .HasDefaultValue(0.0m)
            .IsRequired();

         builder.Property(e => e.TravelExpensesDeduction)
            .HasColumnName("travel_expenses_deduction")
            .HasPrecision(18, 2)
            .HasDefaultValue(0.0m)
            .IsRequired();

         builder.Ignore(e => e.TotalDeduction);

         builder.Property(e => e.PayrollId)
            .HasColumnName("payroll_id")
            .IsRequired(false);

         builder.Property(e => e.OrdinaryPayrollId)
            .HasColumnName("ordinary_payroll_id")
            .IsRequired(false);

         builder.Property(e => e.DisciplinaryFaultId)
            .HasColumnName("disciplinary_fault_id")
            .IsRequired(false);

         builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

         builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

         // Índices
         builder.HasIndex(e => new { e.CollaboratorId, e.Date })
            .IsUnique()
            .HasDatabaseName("ix_absences_collaborator_id_date");

         builder.HasIndex(e => e.Date)
            .HasDatabaseName("ix_absences_date");

         builder.HasIndex(e => e.Status)
            .HasDatabaseName("ix_absences_status");

         builder.HasIndex(e => e.Source)
            .HasDatabaseName("ix_absences_source");

         builder.HasIndex(e => e.PayrollId)
            .HasDatabaseName("ix_absences_payroll_id");

         builder.HasIndex(e => e.OrdinaryPayrollId)
            .HasDatabaseName("ix_absences_ordinary_payroll_id");

         builder.HasIndex(e => e.DisciplinaryFaultId)
            .HasDatabaseName("ix_absences_disciplinary_fault_id");

         // Relaciones
         builder.HasOne(e => e.Collaborator)
            .WithMany(c => c.Absences)
            .HasForeignKey(e => e.CollaboratorId)
            .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(e => e.Payroll)
            .WithMany(p => p.Absences)
            .HasForeignKey(e => e.PayrollId)
            .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(e => e.OrdinaryPayroll)
            .WithMany(op => op.Absences)
            .HasForeignKey(e => e.OrdinaryPayrollId)
            .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(e => e.DisciplinaryFault)
            .WithMany(f => f.Absences)
            .HasForeignKey(e => e.DisciplinaryFaultId)
            .OnDelete(DeleteBehavior.Restrict);
      }
   }
}
