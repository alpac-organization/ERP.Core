

using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class RecordsTravelExpensePaymentsConfiguration : IEntityTypeConfiguration<RecordsTravelExpensePayments>
    {
        public void Configure(EntityTypeBuilder<RecordsTravelExpensePayments> builder)
        {
            builder.ToTable("records_travel_expense_payments");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("records_travel_expense_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.HasIndex(e => e.CollaboratorId)
                .IsUnique()
                .HasDatabaseName("ix_record_travel_expense_collaborator_id");

            builder.Property(e => e.PayrollId)
                .HasColumnName("payroll_id")
                .IsRequired();

            builder.Property(e => e.Transport)
                .HasColumnName("transport")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.Feeding)
                .HasColumnName("feeding")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.Lodging)
                .HasColumnName("lodging")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.PaidDays)
                .HasColumnName("paid_days")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(d => d.Payroll)
                .WithMany(p => p.RecordsTravelExpensePayments)
                .HasForeignKey(d => d.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(c => c.Collaborator)
                .WithMany(s => s.RecordsTravelExpensePayments)
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);    
            
        }
    }
}