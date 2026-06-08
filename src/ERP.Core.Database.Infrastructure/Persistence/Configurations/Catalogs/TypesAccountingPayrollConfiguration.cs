using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs
{
    public class TypesAccountingPayrollConfiguration : IEntityTypeConfiguration<TypesAccountingPayroll>
    {
        public void Configure(EntityTypeBuilder<TypesAccountingPayroll> builder)
        {
            builder.ToTable("types_accounting_payroll");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("type_income_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.AccountingPayrollCode)
                .HasColumnName("accounting_payroll_code")
                .IsRequired();

            builder.Property(e => e.AccountingPayrollName)
                .HasColumnName("accounting_payroll_name ")
                .IsRequired(false);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");
        }
    }
}