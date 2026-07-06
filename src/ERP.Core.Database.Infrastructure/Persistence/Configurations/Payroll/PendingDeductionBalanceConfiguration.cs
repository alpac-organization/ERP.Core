using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class PendingDeductionBalancesConfiguration : IEntityTypeConfiguration<PendingDeductionBalance>
    {
        public void Configure(EntityTypeBuilder<PendingDeductionBalance> builder)
        {
            builder.ToTable("pending_deduction_balances");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("pending_deduction_balance_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.Id)
                .IsUnique()
                .HasDatabaseName("ix_pending_deduction_balance_id");

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.OriginPayrollId)
                .HasColumnName("origin_payroll_id")
                .IsRequired();

            builder.Property(e => e.RecoveredPayrollId)
            .HasColumnName("recovered_payroll_id")
            .IsRequired(false);

            builder.Property(e => e.AmountOwed)
                .HasColumnName("amount_owed")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.Reason)
                .HasColumnName("reason")
                .IsRequired(false);

            builder.Property(e => e.IsRecovered)
                .HasColumnName("is_recovered")
                .IsRequired();

            builder.HasIndex(e => new { e.CollaboratorId, e.IsRecovered })
            .HasDatabaseName("ix_pending_deduction_balances_collaborator_is_recovered");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(c => c.Collaborator)
                .WithMany(collab => collab.PendingDeductionBalances)
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.OriginPayroll)
                .WithMany(payroll => payroll.PendingDeductionBalances)
                .HasForeignKey(s => s.OriginPayrollId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.RecoveredPayroll)
                .WithMany(p => p.RecoveredPendingDeductionBalances)
                .HasForeignKey(s => s.RecoveredPayrollId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }
    }
}