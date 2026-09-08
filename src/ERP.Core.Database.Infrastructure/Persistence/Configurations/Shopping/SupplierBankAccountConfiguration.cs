using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class SupplierBankAccountConfiguration : IEntityTypeConfiguration<SupplierBankAccount>
    {
        public void Configure(EntityTypeBuilder<SupplierBankAccount> builder)
        {
            builder.ToTable("supplier_bank_accounts");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("supplier_bank_account_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired();

            builder.Property(e => e.BankName)
                .HasColumnName("bank_name")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.AccountNumber)
                .HasColumnName("account_number")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.AccountType)
                .HasColumnName("account_type")
                .HasColumnType("bank_account_type_enum")
                .HasDefaultValueSql("'savings'::bank_account_type_enum")
                .IsRequired();

            builder.Property(e => e.Currency)
                .HasColumnName("currency")
                .HasColumnType("currency_enum")
                .HasDefaultValueSql("'nio'::currency_enum")
                .IsRequired();

            builder.Property(e => e.AccountHolderName)
                .HasColumnName("account_holder_name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.AccountHolderIdentification)
                .HasColumnName("account_holder_identification")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(e => e.IsPrimary)
                .HasColumnName("is_primary")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.Supplier)
                .WithMany(s => s.SupplierBankAccounts)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
