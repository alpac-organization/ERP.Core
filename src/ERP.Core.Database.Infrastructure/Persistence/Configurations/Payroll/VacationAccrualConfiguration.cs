using ERP.Core.Database.Domain.Entities.Payrolls;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class VacationAccrualConfiguration : IEntityTypeConfiguration<VacationAccrual>
    {
        public void Configure(EntityTypeBuilder<VacationAccrual> builder)
        {
            builder.ToTable("vacations_accruals");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("vacation_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.BeginningBalance)
                .HasColumnName("beginning_balance")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.FinalBalance)
                .HasColumnName("final_balance")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.AvailableVacations)
                .HasColumnName("available_vacations")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.EquivalentQuantity)
                .HasColumnName("equivalent_quantity")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.EquivalentQuantityInDollars)
                .HasColumnName("equivalent_quantity_in_dollars")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.IndemnificationYears)
                .HasColumnName("indemnification_years")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.IndemnificationValue)
                .HasColumnName("indemnification_value")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.PayrollId)
                .HasColumnName("payroll_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(d => d.Payroll)
                .WithMany(p => p.VacationAccruals)
                .HasForeignKey(d => d.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Collaborator)
                .WithMany(s => s.VacationAccruals)
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}