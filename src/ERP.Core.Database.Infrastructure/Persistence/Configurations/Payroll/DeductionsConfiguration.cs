using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class DeductionsConfiguration : IEntityTypeConfiguration<Deduction>
    {
        public void Configure(EntityTypeBuilder<Deduction> builder)
        {
            builder.ToTable("deductions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("deduction_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.Id)
                .IsUnique()
                .HasDatabaseName("ix_deduction_id");
            
            builder.Property(e => e.Type)
                .HasColumnName("deduction_type")
                .HasColumnType("deduction_type_enum")
                .IsRequired();

            builder.Property(e => e.Currency)
                .HasColumnName("currency")
                .HasColumnType("currency_enum")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("deduction_status_enum")
                .IsRequired();

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired(false);

            builder.Property(e => e.Percentage)
                .HasColumnName("percentage")
                .IsRequired(false);
                
            builder.Property(e => e.Amount)
                .HasColumnName("amount")
                .IsRequired(false);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired(false);

            builder.Property(e => e.FortnightlyAmount)
                .HasColumnName("fortnightly_amount")
                .HasPrecision(18, 2)
                .IsRequired(false);

            builder.Property(e => e.FortnightlyAmountInDollars)
                .HasColumnName("fortnightly_amount_in_dollars")
                .HasPrecision(18, 2)
                .IsRequired(false);

            builder.Property(e => e.NumberFortnights)
                .HasColumnName("number_fortnights")
                .IsRequired(false);

            builder.Property(e => e.NumberFortnightsPaid)
                .HasColumnName("number_fortnights_paid")
                .IsRequired(false);

            builder.Property(e => e.AmountPaid)
                .HasColumnName("amount_paid")
                .HasPrecision(18, 2)
                .IsRequired(false);            

            builder.Property(e => e.AmountPaidInDollars)
                .HasColumnName("amount_paid_in_dollars")
                .HasPrecision(18, 2)
                .IsRequired(false);       

            builder.Property(e => e.TotalBalance)
                .HasColumnName("total_balance")
                .HasPrecision(18, 2)
                .IsRequired(false);

            builder.Property(e => e.TotalBalanceInDollars)
                .HasColumnName("total_balance_in_dollars")
                .HasPrecision(18, 2)
                .IsRequired(false);

            builder.Property(e => e.TotalAmount)
                .HasColumnName("total_amount")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.TotalAmountInDollars)
                .HasColumnName("total_amount_in_dollars")
                .HasPrecision(18, 2)
                .IsRequired();
             
            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(c => c.Collaborator)
                .WithMany(s => s.Deductions)
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.PaymentHistories)
                .WithOne(s => s.Deduction)
                .HasForeignKey(s => s.DeductionId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}