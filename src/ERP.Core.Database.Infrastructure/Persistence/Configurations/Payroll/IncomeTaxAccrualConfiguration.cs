using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class IncomeTaxAccrualConfiguration : IEntityTypeConfiguration<IncomeTaxAccrual>
    {
        public void Configure(EntityTypeBuilder<IncomeTaxAccrual> builder)
        {
            builder.ToTable("income_tax_accrual");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("income_tax_accrual_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.Id)
                .IsUnique()
                .HasDatabaseName("ix_income_tax_id");

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.PayrollId)
                .HasColumnName("payroll_id")
                .IsRequired();

            builder.Property(e => e.AccumulatedSeniority)
                .HasColumnName("accumulated_seniority")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.AccumulatedIrByFornight)
                .HasColumnName("accumulated_ir_by_fornight")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.SalaryEarnedByFornight)
                .HasColumnName("salary_earned_by_fornight")
                .HasPrecision(18, 2)
                .IsRequired();
            
            builder.Property(e => e.AccumulatedIrMonthly)
                .HasColumnName("accumulated_ir_monthly")
                .HasPrecision(18, 2)
                .IsRequired(false);
            
            builder.Property(e => e.SalaryEarnedMonthly)
                .HasColumnName("salary_earned_monthly")
                .HasPrecision(18, 2)
                .IsRequired(false);

            builder.Property(e => e.NumberOfFortnights)
                .HasColumnName("number_of_fortnights")
                .IsRequired();

            builder.Property(e => e.FlagNumberOfFortnights)
                .HasColumnName("flag_number_of_fortnights")
                .IsRequired();

            builder.Property(e => e.SalaryEarned)
                .HasPrecision(18, 2)
                .HasColumnName("salary_earned")
                .IsRequired();

            builder.Property(e => e.FlagSalaryEarned)
                .HasPrecision(18, 2)
                .HasColumnName("flag_salary_earned")
                .IsRequired();

            builder.Property(e => e.AccumulatedIR)
                .HasPrecision(18, 2)
                .HasColumnName("accumulated_ir")
                .IsRequired();

            builder.Property(e => e.FlagAccumulatedIR)
                .HasPrecision(18, 2)
                .HasColumnName("flag_accumulated_ir")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(c => c.Collaborator)
                .WithMany(s => s.IncomeTaxAccruals)
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Payroll)
                .WithMany(s => s.IncomeTaxAccruals)
                .HasForeignKey(d => d.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}