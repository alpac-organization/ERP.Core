using ERP.Core.Database.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class PayrollsConfiguration : IEntityTypeConfiguration<Domain.Entities.Payrolls.Payroll>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Payrolls.Payroll> builder)
        {
            builder.ToTable("payrolls");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("payroll_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.Id)
                .IsUnique()
                .HasDatabaseName("ix_payroll_id");

            builder.Property(e => e.Status)
                .HasColumnName("payroll_status")
                .HasColumnType("payroll_status_enum")
                .IsRequired();

            builder.Property(e => e.BranchId)
                .HasColumnName("company_branch_id")
                .IsRequired();

            builder.Property(e => e.TypeAccountingId)
                .HasColumnName("type_accounting_id")
                .IsRequired(false);

            builder.Property(e => e.PayrollType)
                .HasColumnName("payroll_type")
                .HasColumnType("payroll_type_enum");

            builder.Property(e => e.Period)
                .HasColumnName("payroll_period")
                .HasColumnType("payroll_period_enum");

            builder.Property(e => e.StartDate)
                .HasColumnName("start_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.EndDate)
                .HasColumnName("end_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(c => c.Branch)
                .WithMany(s => s.Payrolls)
                .HasForeignKey(s => s.BranchId)
                .OnDelete(DeleteBehavior.Restrict);    

            //Reporte de nomina ordinaria.
            builder.HasMany(c => c.OrdinaryPayrolls)
                .WithOne(s => s.Payroll)
                .HasForeignKey(s => s.PayrollId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.PermitApplications)
                .WithOne(s => s.Payroll)
                .HasForeignKey(s => s.PayrolId)
                .OnDelete(DeleteBehavior.Cascade);

            //Acumulado de ir, devengado en la quincena
            builder.HasMany(c => c.IncomeTaxAccruals)
                .WithOne(s => s.Payroll)
                .HasForeignKey(s => s.PayrollId)
                .OnDelete(DeleteBehavior.Cascade);

            //Acumulado de vacaciones
            builder.HasMany(c => c.VacationAccruals)
                .WithOne(s => s.Payroll)
                .HasForeignKey(s => s.PayrollId)
                .OnDelete(DeleteBehavior.Cascade);
                
            //Registro de pago de viaticos de la quincena
            builder.HasMany(c => c.RecordsTravelExpensePayments)
                .WithOne(s => s.Payroll)
                .HasForeignKey(s => s.PayrollId)
                .OnDelete(DeleteBehavior.Cascade);        

            //Acumulado de aguinaldo
            builder.HasMany(c => c.ChristmasBonusAccruals)
                .WithOne(s => s.Payroll)
                .HasForeignKey(s => s.PayrollId)
                .OnDelete(DeleteBehavior.Cascade);        
        }
    }
}