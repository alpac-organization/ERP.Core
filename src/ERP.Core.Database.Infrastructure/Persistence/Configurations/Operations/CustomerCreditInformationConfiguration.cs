using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Operations
{
    public class CustomerCreditInformationConfiguration : IEntityTypeConfiguration<CustomerCreditInformation>
    {
        public void Configure(EntityTypeBuilder<CustomerCreditInformation> builder)
        {
            builder.ToTable("customer_credit_information");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .HasColumnName("customer_credit_information_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.CreditDays)
                .HasColumnName("credit_days")
                .IsRequired();

            builder.Property(ci => ci.PaymentCondition)
                .HasColumnName("payment_condition")
                .HasColumnType("payment_condition_enum")
                .IsRequired();

            builder.Property(ci => ci.Currency)
                .HasColumnName("currency")
                .HasColumnType("currency_enum")
                .HasDefaultValueSql("'nio'::currency_enum")
                .IsRequired();

            builder.Property(ci => ci.BranchId)
                .HasColumnName("branch_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(ci => ci.Branch)
                .WithMany(cb => cb.CreditInformation)
                .HasForeignKey(ci => ci.BranchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ci => ci.BranchId)
                .HasDatabaseName("ix_customer_credit_information_branch_id");

            builder.HasIndex(ci => new { ci.BranchId, ci.PaymentCondition })
                .HasDatabaseName("ix_customer_credit_information_branch_payment_condition")
                .IsUnique();
        }
    }
}