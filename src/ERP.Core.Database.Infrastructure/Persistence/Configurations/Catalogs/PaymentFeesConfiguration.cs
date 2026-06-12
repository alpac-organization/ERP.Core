using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
    public class PaymentFeesConfiguration : IEntityTypeConfiguration<PaymentFees>
    {
        public void Configure(EntityTypeBuilder<PaymentFees> builder)
        {
            builder.ToTable("payment_fees");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("payment_fess_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Amount)
                .HasColumnName("amount")
                .HasMaxLength(180)
                .IsRequired();

            builder.Property(e => e.Currency)
                .HasColumnName("currency")
                .HasColumnType("currency_enum")
                .IsRequired();

            builder.Property(e => e.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasIndex(e => e.Id)
                .HasDatabaseName("ix_payment_fees_id");
        }
    }
}