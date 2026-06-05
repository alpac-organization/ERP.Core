using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    //✅Reporte del inss quincenal y mensual
    public class InssAccountingInformationConfiguration : IEntityTypeConfiguration<InssAccountingInformation>
    {
        public void Configure(EntityTypeBuilder<InssAccountingInformation> builder)
        {
            builder.ToTable("inss_accounting_information");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("inss_information_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.Id)
                .IsUnique()
                .HasDatabaseName("ix_inss_information_id");

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.PayrollId)
                .HasColumnName("payroll_id")
                .IsRequired();

            builder.Property(e => e.Inatec)
                .HasPrecision(18,2)
                .HasColumnName("inatec")
                .IsRequired();

            builder.Property(e => e.DaysAbsence)
                .HasColumnName("days_absence")
                .IsRequired();

            builder.Property(e => e.InssLabor)
                .HasPrecision(18,2)
                .HasColumnName("inss_labor")
                .IsRequired();

            builder.Property(e => e.InssPatronal)
                .HasPrecision(18,2)
                .HasColumnName("inss_patronal")
                .IsRequired(); 

            builder.Property(e => e.Absence)
                .HasPrecision(18,2)
                .HasColumnName("absence")
                .IsRequired(); 

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(c => c.Collaborator)
                .WithMany(s => s.InssAccountingInformation)
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Payroll)
                .WithMany(s => s.InssAccountingInformation)
                .HasForeignKey(d => d.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}