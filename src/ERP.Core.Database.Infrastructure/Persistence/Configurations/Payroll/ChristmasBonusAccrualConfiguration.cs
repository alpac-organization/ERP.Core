

using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class ChristmasBonusAccrualConfiguration : IEntityTypeConfiguration<ChristmasBonusAccrual>
    {
        public void Configure(EntityTypeBuilder<ChristmasBonusAccrual> builder)
        {
            builder.ToTable("christmas_bonus_accruals");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("christmas_bonus_accrual_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.HasIndex(e => e.CollaboratorId)
                .IsUnique()
                .HasDatabaseName("ix_christmas_bonus_collaborator_id");

            builder.Property(x => x.ChristmasBonusPeriodId)
              .IsRequired();

            builder.Property(x => x.AccrualYear)
           .IsRequired();

            builder.Property(x => x.AccrualMonth)
                 .IsRequired();

            builder.Property(x => x.CoveredFrom)
                .IsRequired();

            builder.Property(x => x.CoveredTo)
                .IsRequired();

            builder.Property(x => x.EligibleDays)
                .IsRequired();

            builder.Property(x => x.ChristmasBonusDays)
                .IsRequired();

            builder.Property(x => x.BaseSalarySnapshot)
               .IsRequired();

            builder.Property(x => x.AccruedAmount)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.IsProjected)
                .IsRequired();

            builder.Property(x => x.Revision)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(x => x.CalculationReason)
                .IsRequired();

            builder.Property(x => x.IsCurrent)
                .IsRequired()
                .HasDefaultValue(true);


            builder.Property(x => x.EligibleDays)
            .HasPrecision(9, 4);

            builder.Property(x => x.ChristmasBonusDays)
                .HasPrecision(9, 4);

            builder.Property(x => x.BaseSalarySnapshot)
                .HasPrecision(18, 4);

            builder.Property(x => x.AccruedAmount)
                .HasPrecision(18, 4);

            builder.Property(x => x.AccruedAmountInDollars)
                .HasPrecision(18, 4);

            builder.Property(e => e.PayrollId)
                .HasColumnName("payroll_id")
                .IsRequired();



            builder.Property(e => e.ChristmasBonusDays)
                .HasColumnName("christmas_bonus_days")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");


            //relationships 

            builder.HasOne(x => x.ChristmasBonusPeriod)
               .WithMany(x => x.Accruals)
               .HasForeignKey(x => x.ChristmasBonusPeriodId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Collaborator)
                .WithMany(x => x.ChristmasBonusAccruals)
                .HasForeignKey(x => x.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Payroll)
                .WithMany(x => x.ChristmasBonusAccruals)
                .HasForeignKey(x => x.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.ReplacesAccrual)
               .WithMany()
               .HasForeignKey(x => x.ReplacesAccrualId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Payroll)
                .WithMany(p => p.ChristmasBonusAccruals)
                .HasForeignKey(d => d.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Collaborator)
                .WithMany(s => s.ChristmasBonusAccruals)
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);


            //aqui indexes 

            builder.HasIndex(x => new
            {
                x.CollaboratorId,
                x.ChristmasBonusPeriodId
            });

            builder.HasIndex(x => new
            {
                x.ChristmasBonusPeriodId,
                x.AccrualYear,
                x.AccrualMonth
            });

            //acumulado unico por colaborator de aguinaldo por periodo
            builder.HasIndex(x => new
            {
                x.ChristmasBonusPeriodId,
                x.CollaboratorId,
                x.AccrualYear,
                x.AccrualMonth
            })
            .IsUnique()
            .HasFilter("\"IsCurrent\" = TRUE");
        }
    }
}