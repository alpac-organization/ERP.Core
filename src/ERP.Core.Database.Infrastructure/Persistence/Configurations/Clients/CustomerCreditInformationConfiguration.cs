using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Clients;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Clients
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

            builder.Property(ci => ci.MaxBalance)
                .HasColumnName("max_balance")
                .HasColumnType("decimal(18,2)")
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

            builder.Property(ci => ci.CreditStatus)
                .HasColumnName("credit_status")
                .HasColumnType("credit_status_enum")
                .HasDefaultValueSql("'active'::credit_status_enum")
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

            builder.HasOne(c => c.Branch)
                .WithMany()
                .HasForeignKey(c => c.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}