using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class ChristmasBonusAccrualConfiguration : IEntityTypeConfiguration<ChristmasBonusAccrual>
    {
        public void Configure(EntityTypeBuilder<ChristmasBonusAccrual> builder)
        {
            builder.ToTable("christmas_bonus_accruals", table =>
            {
                table.HasCheckConstraint(
                    "ck_christmas_bonus_accruals_covered_dates",
                    "\"covered_to\" >= \"covered_from\"");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_accruals_month",
                    "\"accrual_month\" >= 1 AND \"accrual_month\" <= 12");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_accruals_eligible_days",
                    "\"eligible_days\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_accruals_days",
                    "\"christmas_bonus_days\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_accruals_base_salary",
                    "\"base_salary_snapshot\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_accruals_amount",
                    "\"accrued_amount\" >= 0");
            });

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("christmas_bonus_accrual_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.ChristmasBonusPeriodId)
                .HasColumnName("christmas_bonus_period_id")
                .IsRequired();

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.PayrollId)
                .HasColumnName("payroll_id")
                .IsRequired();

            builder.Property(e => e.AccrualYear)
                .HasColumnName("accrual_year")
                .IsRequired();

            builder.Property(e => e.AccrualMonth)
                .HasColumnName("accrual_month")
                .IsRequired();

            builder.Property(e => e.CoveredFrom)
                .HasColumnName("covered_from")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.CoveredTo)
                .HasColumnName("covered_to")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.EligibleDays)
                .HasColumnName("eligible_days")
                .HasPrecision(9, 4)
                .IsRequired();

            builder.Property(e => e.ChristmasBonusDays)
                .HasColumnName("christmas_bonus_days")
                .HasPrecision(9, 4)
                .IsRequired();

            builder.Property(e => e.BaseSalarySnapshot)
                .HasColumnName("base_salary_snapshot")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(e => e.AccruedAmount)
                .HasColumnName("accrued_amount")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(e => e.AccruedAmountInDollars)
                .HasColumnName("accrued_amount_in_dollars")
                .HasPrecision(18, 4);

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(e => e.IsProjected)
                .HasColumnName("is_projected")
                .IsRequired();

            builder.Property(e => e.Revision)
                .HasColumnName("revision")
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(e => e.CalculationReason)
                .HasColumnName("calculation_reason")
                .IsRequired();

            builder.Property(e => e.IsCurrent)
                .HasColumnName("is_current")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.ReplacesAccrualId)
                .HasColumnName("replaces_accrual_id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.ChristmasBonusPeriod)
                .WithMany(e => e.Accruals)
                .HasForeignKey(e => e.ChristmasBonusPeriodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Collaborator)
                .WithMany(e => e.ChristmasBonusAccruals)
                .HasForeignKey(e => e.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Payroll)
                .WithMany(e => e.ChristmasBonusAccruals)
                .HasForeignKey(e => e.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ReplacesAccrual)
                .WithMany()
                .HasForeignKey(e => e.ReplacesAccrualId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => new
            {
                e.CollaboratorId,
                e.ChristmasBonusPeriodId
            })
            .HasDatabaseName("ix_christmas_bonus_accruals_collaborator_period");

            builder.HasIndex(e => new
            {
                e.ChristmasBonusPeriodId,
                e.AccrualYear,
                e.AccrualMonth
            })
            .HasDatabaseName("ix_christmas_bonus_accruals_period_year_month");

            builder.HasIndex(e => e.PayrollId)
                .HasDatabaseName("ix_christmas_bonus_accruals_payroll_id");

            builder.HasIndex(e => new
            {
                e.ChristmasBonusPeriodId,
                e.CollaboratorId,
                e.AccrualYear,
                e.AccrualMonth
            })
            .IsUnique()
            .HasFilter("\"is_current\" = TRUE AND \"deleted_at\" IS NULL")
            .HasDatabaseName("ux_christmas_bonus_accruals_current_month");
        }
    }
}
