using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class ChristmasBonusAdvanceConfiguration
        : IEntityTypeConfiguration<ChristmasBonusAdvance>
    {
        public void Configure(
            EntityTypeBuilder<ChristmasBonusAdvance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("christmas_bonus_advance_id")
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

            builder.Property(x => x.Currency)
                .HasColumnName("currency")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(x => x.RequestedAt)
                .HasColumnName("requested_at")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.RequestedBy)
                .HasColumnName("requested_by");

            builder.Property(x => x.ApprovedAt)
                .HasColumnName("approved_at")
                .HasColumnType("date");

            builder.Property(x => x.ApprovedBy)
                .HasColumnName("approved_by");

            builder.Property(x => x.PaidAt)
                .HasColumnName("paid_at")
                .HasColumnType("date");

            builder.Property(x => x.PaidBy)
                .HasColumnName("paid_by");

            builder.Property(x => x.CancelledAt)
                .HasColumnName("cancelled_at")
                .HasColumnType("date");

            builder.Property(x => x.CancelledBy)
                .HasColumnName("cancelled_by");

            builder.Property(x => x.CancellationReason)
                .HasColumnName("cancellation_reason")
                .HasMaxLength(1000);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.DeletedAt)
                .HasColumnName("deleted_at");



            builder.Property(x => x.Amount)
                .HasPrecision(18, 4);

            builder.Property(x => x.AmountInDollars)
                .HasPrecision(18, 4);

            builder.HasIndex(x => new
            {
                x.CollaboratorId,
                x.ChristmasBonusPeriodId,
                x.Status
            });


            builder.HasOne(x => x.ChristmasBonusPeriod)
                .WithMany(x => x.Advances)
                .HasForeignKey(x => x.ChristmasBonusPeriodId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Collaborator)
                .WithMany(x => x.ChristmasBonusAdvances)
                .HasForeignKey(x => x.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Payroll)
                .WithMany(x => x.ChristmasBonusAdvances)
                .HasForeignKey(x => x.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.ToTable("christmas_bonus_advances",table =>
            {
                table.HasCheckConstraint(
                    "CK_ChristmasBonusAdvance_Amount",
                    "\"Amount\" > 0");

                table.HasCheckConstraint(
                    "CK_ChristmasBonusAdvance_LocalAmount",
                    "\"AmountInDollars\" > 0");
            });
        }
    }
}