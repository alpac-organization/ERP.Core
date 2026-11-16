using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class ChristmasBonusSettlementConfiguration
        : IEntityTypeConfiguration<ChristmasBonusSettlement>
    {
        public void Configure(EntityTypeBuilder<ChristmasBonusSettlement> builder)
        {
            builder.ToTable("christmas_bonus_settlements", table =>
            {
                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlements_reference_salary",
                    "\"reference_salary\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlements_eligible_days",
                    "\"eligible_days\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlements_days",
                    "\"christmas_bonus_days\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlements_gross",
                    "\"gross_entitlement\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlements_advances",
                    "\"advances_paid\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlements_child_support",
                    "\"child_support_withholding\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlements_amount_to_pay",
                    "\"amount_to_pay\" >= 0");
            });

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("christmas_bonus_settlement_id")
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
                .HasColumnName("payroll_id");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(e => e.CutoffDate)
                .HasColumnName("cutoff_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.SalaryTypeSnapshot)
                .HasColumnName("salary_type_snapshot")
                .IsRequired();

            builder.Property(e => e.ReferenceSalary)
                .HasColumnName("reference_salary")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(e => e.EligibleDays)
                .HasColumnName("eligible_days")
                .HasPrecision(9, 4)
                .IsRequired();

            builder.Property(e => e.ChristmasBonusDays)
                .HasColumnName("christmas_bonus_days")
                .HasPrecision(9, 4)
                .IsRequired();

            builder.Property(e => e.GrossEntitlement)
                .HasColumnName("gross_entitlement")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(e => e.AdvancesPaid)
                .HasColumnName("advances_paid")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(e => e.ChildSupportWithholding)
                .HasColumnName("child_support_withholding")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(e => e.AmountToPay)
                .HasColumnName("amount_to_pay")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(e => e.AmountToPayInDollars)
                .HasColumnName("amount_to_pay_in_dollars")
                .HasPrecision(18, 4);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.ChristmasBonusPeriod)
                .WithMany(e => e.Settlements)
                .HasForeignKey(e => e.ChristmasBonusPeriodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Collaborator)
                .WithMany(e => e.ChristmasBonusSettlements)
                .HasForeignKey(e => e.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Payroll)
                .WithMany(e => e.ChristmasBonusSettlements)
                .HasForeignKey(e => e.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => new
            {
                e.ChristmasBonusPeriodId,
                e.CollaboratorId
            })
            .IsUnique()
            .HasFilter("\"deleted_at\" IS NULL")
            .HasDatabaseName("ux_christmas_bonus_settlements_period_collaborator");

            builder.HasIndex(e => e.PayrollId)
                .HasDatabaseName("ix_christmas_bonus_settlements_payroll_id");
        }
    }
}
