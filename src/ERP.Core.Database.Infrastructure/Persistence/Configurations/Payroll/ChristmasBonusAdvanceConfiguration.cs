using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class ChristmasBonusAdvanceConfiguration
        : IEntityTypeConfiguration<ChristmasBonusAdvance>
    {
        public void Configure(EntityTypeBuilder<ChristmasBonusAdvance> builder)
        {
            builder.ToTable("christmas_bonus_advances", table =>
            {
                table.HasCheckConstraint(
                    "ck_christmas_bonus_advances_amount",
                    "\"amount\" > 0");

            });

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("christmas_bonus_advance_id")
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

            builder.Property(e => e.Currency)
                .HasColumnName("currency")
                .HasColumnType("currency_enum")
                .IsRequired();

            builder.Property(e => e.Amount)
                .HasColumnName("amount")
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("christmas_bonus_advance_status_enum")
                .IsRequired();

            builder.Property(e => e.RequestedAt)
                .HasColumnName("requested_at")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.RequestedById)
                .HasColumnName("requested_by_id");

            builder.Property(e => e.ApprovedAt)
                .HasColumnName("approved_at")
                .HasColumnType("date");

            builder.Property(e => e.ApprovedById)
                .HasColumnName("approved_by_id");

            builder.Property(e => e.PaidAt)
                .HasColumnName("paid_at")
                .HasColumnType("date");

            builder.Property(e => e.PaidById)
                .HasColumnName("paid_by_id");

            builder.Property(e => e.CancelledAt)
                .HasColumnName("cancelled_at")
                .HasColumnType("date");

            builder.Property(e => e.CancelledById)
                .HasColumnName("cancelled_by_id");

            builder.Property(e => e.CancellationReason)
                .HasColumnName("cancellation_reason")
                .HasMaxLength(1000);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.ChristmasBonusPeriod)
                .WithMany(e => e.Advances)
                .HasForeignKey(e => e.ChristmasBonusPeriodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Collaborator)
                .WithMany(e => e.ChristmasBonusAdvances)
                .HasForeignKey(e => e.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Payroll)
                .WithMany(e => e.ChristmasBonusAdvances)
                .HasForeignKey(e => e.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.RequestedBy)
                .WithMany()
                .HasForeignKey(e => e.RequestedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ApprovedBy)
                .WithMany()
                .HasForeignKey(e => e.ApprovedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PaidBy)
                .WithMany()
                .HasForeignKey(e => e.PaidById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CancelledBy)
                .WithMany()
                .HasForeignKey(e => e.CancelledById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => new
            {
                e.CollaboratorId,
                e.ChristmasBonusPeriodId,
                e.Status
            })
            .HasDatabaseName("ix_christmas_bonus_advances_collaborator_period_status");

            builder.HasIndex(e => e.PayrollId)
                .HasDatabaseName("ix_christmas_bonus_advances_payroll_id");
        }
    }
}
