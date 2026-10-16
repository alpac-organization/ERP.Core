

using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
   public class DisciplinarySanctionConfiguration : IEntityTypeConfiguration<DisciplinarySanction>
   {
      public void Configure(EntityTypeBuilder<DisciplinarySanction> builder)
      {
         builder.ToTable("disciplinary_sanctions");

         builder.HasKey(e => e.Id);

         builder.Property(e => e.Id)
            .HasColumnName("disciplinary_sanction_id")
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd()
            .IsRequired();

         builder.HasIndex(e => e.Id)
            .IsUnique()
            .HasDatabaseName("ix_disciplinary_sanction_id");

         builder.Property(e => e.FaultId)
            .HasColumnName("fault_id")
            .IsRequired();

         builder.Property(e => e.SanctionType)
            .HasColumnName("sanction_type")
            .HasColumnType("sanction_type_enum")
            .IsRequired();

         builder.Property(e => e.SanctionStatus)
            .HasColumnName("sanction_status")
            .HasColumnType("sanction_status_enum")
            .IsRequired();

         builder.Property(e => e.SuspensionStartDate)
            .HasColumnName("suspension_start_date")
            .HasColumnType("date")
            .IsRequired(false);

         builder.Property(e => e.SuspensionEndDate)
            .HasColumnName("suspension_end_date")
            .HasColumnType("date")
            .IsRequired(false);

         builder.Property(e => e.PayrollId)
            .HasColumnName("payroll_id")
            .IsRequired(false);

         builder.Property(e => e.Reason)
            .HasColumnName("reason")
            .HasMaxLength(500)
            .IsRequired();

         builder.Property(e => e.IssuedBy)
            .HasColumnName("issued_by")
            .IsRequired();

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

         builder.HasIndex(e => e.FaultId)
            .HasDatabaseName("ix_disciplinary_sanctions_fault_id");

         builder.HasIndex(e => e.PayrollId)
            .HasDatabaseName("ix_disciplinary_sanctions_payroll_id");

         builder.HasOne(e => e.Fault)
            .WithMany(f => f.Sanctions)
            .HasForeignKey(e => e.FaultId)
            .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(e => e.Payroll)
            .WithMany(p => p.DisciplinarySanctions)
            .HasForeignKey(e => e.PayrollId)
            .OnDelete(DeleteBehavior.Restrict);
      }
   }
}