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
                    "ck_christmas_bonus_settlement_reference_salary",
                    "\"reference_salary\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlement_eligible_days",
                    "\"eligible_days\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlement_days",
                    "\"christmas_bonus_days\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlement_gross",
                    "\"gross_entitlement\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlement_advances",
                    "\"advances_paid\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlement_child_support",
                    "\"child_support_withholding\" >= 0");

                table.HasCheckConstraint(
                    "ck_christmas_bonus_settlement_amount_to_pay",
                    "\"amount_to_pay\" >= 0");
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("christmas_bonus_settlement_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.ChristmasBonusPeriodId)
                .HasColumnName("christmas_bonus_period_id")
                .IsRequired();

            builder.Property(x => x.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(x => x.PayrollId)
                .HasColumnName("payroll_id");

            builder.Property(x => x.Type)
                .HasColumnName("type")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(x => x.CutoffDate)
                .HasColumnName("cutoff_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.SalaryTypeSnapshot)
                .HasColumnName("salary_type_snapshot")
                .IsRequired();

            builder.Property(x => x.ReferenceSalary)
                .HasColumnName("reference_salary")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(x => x.EligibleDays)
                .HasColumnName("eligible_days")
                .HasPrecision(9, 4)
                .IsRequired();

            builder.Property(x => x.ChristmasBonusDays)
                .HasColumnName("christmas_bonus_days")
                .HasPrecision(9, 4)
                .IsRequired();

            builder.Property(x => x.GrossEntitlement)
                .HasColumnName("gross_entitlement")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(x => x.AdvancesPaid)
                .HasColumnName("advances_paid")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(x => x.ChildSupportWithholding)
                .HasColumnName("child_support_withholding")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(x => x.AmountToPay)
                .HasColumnName("amount_to_pay")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(x => x.AmountToPayInDollars)
                .HasColumnName("amount_to_pay_in_dollars")
                .HasPrecision(18, 4);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.DeletedAt)
                .HasColumnName("deleted_at");


            builder.HasOne(x => x.ChristmasBonusPeriod)
                .WithMany(x => x.Settlements)
                .HasForeignKey(x => x.ChristmasBonusPeriodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Collaborator)
                .WithMany(x => x.ChristmasBonusSettlements)
                .HasForeignKey(x => x.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Payroll)
                .WithMany(x => x.ChristmasBonusSettlements)
                .HasForeignKey(x => x.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(x => new
            {
                x.ChristmasBonusPeriodId,
                x.CollaboratorId
            })
            .IsUnique()
            .HasFilter("\"deleted_at\" IS NULL")
            .HasDatabaseName("ux_christmas_bonus_settlement_period_collaborator");

            builder.HasIndex(x => x.PayrollId)
                .HasDatabaseName("ix_christmas_bonus_settlement_payroll");
        }
    }
}