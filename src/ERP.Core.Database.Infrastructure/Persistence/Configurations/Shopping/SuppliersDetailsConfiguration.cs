using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Shopping
{
    public class SuppliersDetailsConfiguration : IEntityTypeConfiguration<SupplierDetails>
    {
        public void Configure(EntityTypeBuilder<SupplierDetails> builder)
        {
            builder.ToTable("suppliers_details");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("supplier_detail_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Address)
                .HasColumnName("address")
                .IsRequired(false);

            builder.Property(e => e.ContactName)
                .HasColumnName("contact_name")
                .IsRequired(false);

            builder.Property(e => e.ContactEmail)
                .HasColumnName("contact_email")
                .IsRequired(false);

            builder.Property(e => e.ContactPhoneNumber)
                .HasColumnName("contact_phone_number")
                .IsRequired(false);

            builder.Property(e => e.EmailSupport)
                .HasColumnName("email_support")
                .IsRequired(false);

            builder.Property(e => e.IsExclusive)
                .HasColumnName("is_exclusive")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.ExclusiveBrandsOrParts)
                .HasColumnName("exclusive_brands_or_parts")
                .IsRequired(false);

            builder.Property(e => e.HasCredit)
                .HasColumnName("has_credit")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.CreditDays)
                .HasColumnName("credit_days")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.CreditLimit)
                .HasColumnName("credit_limit")
                .HasPrecision(18, 2)
                .IsRequired(false);

            builder.Property(e => e.CreditCurrency)
                .HasColumnName("credit_currency")
                .HasColumnType("currency_enum")
                .IsRequired(false);

            builder.Property(e => e.AlertDaysBeforeDue)
                .HasColumnName("alert_days_before_due")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.PreferredPaymentMethod)
                .HasColumnName("preferred_payment_method")
                .HasColumnType("payment_method_type_enum")
                .HasDefaultValueSql("'ach'::payment_method_type_enum")
                .IsRequired();

            builder.Property(e => e.ApplyIrRetention)
                .HasColumnName("apply_ir_retention")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.ApplyMunicipalRetention)
                .HasColumnName("apply_municipal_retention")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.IsTaxExempt)
                .HasColumnName("is_tax_exempt")
                .HasDefaultValue(false)
                .IsRequired();


            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at"); 

            builder.HasOne(p => p.Supplier)
                .WithOne(c => c.SupplierDetails)
                .HasForeignKey<SupplierDetails>(p => p.SupplierId) 
                .OnDelete(DeleteBehavior.Restrict);        
        }
    }
}