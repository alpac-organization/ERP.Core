using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class ChristmasBonusPeriodConfiguration : IEntityTypeConfiguration<ChristmasBonusPeriod>
    {
        public void Configure(EntityTypeBuilder<ChristmasBonusPeriod> builder)
        {
            builder.ToTable("christmas_bonus_periods", table =>
            {
                table.HasCheckConstraint(
                    "ck_christmas_bonus_periods_dates",
                    "\"end_date\" >= \"start_date\"");
            });

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("christmas_bonus_period_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();

            builder.Property(e => e.EndYear)
                .HasColumnName("end_year")
                .IsRequired();

            builder.Property(e => e.StartDate)
                .HasColumnName("start_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.EndDate)
                .HasColumnName("end_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasIndex(e => new { e.CompanyId, e.EndYear })
                .IsUnique()
                .HasDatabaseName("ix_christmas_bonus_periods_company_id_end_year");

            builder.HasIndex(e => new { e.CompanyId, e.StartDate, e.EndDate })
                .HasDatabaseName("ix_christmas_bonus_periods_company_id_dates");

            builder.HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Accruals)
                .WithOne(e => e.ChristmasBonusPeriod)
                .HasForeignKey(e => e.ChristmasBonusPeriodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Advances)
                .WithOne(e => e.ChristmasBonusPeriod)
                .HasForeignKey(e => e.ChristmasBonusPeriodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Settlements)
                .WithOne(e => e.ChristmasBonusPeriod)
                .HasForeignKey(e => e.ChristmasBonusPeriodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
