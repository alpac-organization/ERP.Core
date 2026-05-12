using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class ProfessionalServicesPayrollConfiguration : IEntityTypeConfiguration<ProfessionalServicesPayroll>
    {
        public void Configure(EntityTypeBuilder<ProfessionalServicesPayroll> builder)
        {
            builder.ToTable("professional_services_payrolls");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ordinary_payroll_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.Id)
                .IsUnique()
                .HasDatabaseName("ix_ordinary_payroll_id");

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.NumberOfOvertime)
                .HasColumnName("number_of_overtime")
                .IsRequired();

            builder.Property(e => e.Overtime)
                .HasColumnName("overtimes")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.Bonus)
                .HasColumnName("bonus")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.Commissions)
                .HasColumnName("commissions")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.GrossSalary)
                .HasColumnName("gross_salary")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.Inss)
                .HasColumnName("inss")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.Ir)
                .HasColumnName("ir")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.TotalLegalDeductions)
                .HasColumnName("total_legal_deductions")
                .HasPrecision(18, 2)
                .IsRequired();
                
            builder.Property(e => e.Vacations)
                .HasColumnName("vacations")
                .HasPrecision(18, 2);

            builder.Property(e => e.VigemsaAdditionalData)
                .HasColumnName("vigemsa_additional_data")
                .HasColumnType("jsonb");

            builder.Property(e => e.AlpacAdditionalData)
                .HasColumnName("alpac_additional_data")
                .HasColumnType("jsonb");

            builder.Property(e => e.AvasaAdditionalData)
                .HasColumnName("avasa_additional_data")
                .HasColumnType("jsonb");

            builder.Property(e => e.TotalToPay)
                .HasColumnName("total_to_pay")
                .HasPrecision(18, 2)
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

            builder.HasOne(c => c.Collaborator)
                .WithMany(s => s.ProfessionalServicesPayrolls)
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);    
        }
    }
}