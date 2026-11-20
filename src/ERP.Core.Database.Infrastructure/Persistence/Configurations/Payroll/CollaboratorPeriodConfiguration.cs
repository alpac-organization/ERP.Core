using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class CollaboratorPeriodConfiguration
        : IEntityTypeConfiguration<CollaboratorPeriod>
    {
        public void Configure(EntityTypeBuilder<CollaboratorPeriod> builder)
        {
            builder.ToTable("employment_periods", table =>
            {
                table.HasCheckConstraint(
                    "ck_employment_periods_dates",
                    "\"departure_date\" IS NULL OR \"departure_date\" >= \"entry_date\"");
            });

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("employment_period_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e=>e.CollaboratorCode)
                .HasColumnName("collaborator_code")
                .IsRequired();

            builder.Property(e => e.EntryDate)
                .HasColumnName("entry_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.DepartureDate)
                .HasColumnName("departure_date")
                .HasColumnType("date")
                .IsRequired(false);

            builder.Property(e => e.CollaboratorTerminationId)
                .HasColumnName("collaborator_termination_id")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(e => e.Collaborator)
                .WithMany(e => e.EmploymentPeriods)
                .HasForeignKey(e => e.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CollaboratorTermination)
                .WithOne(t => t.EmploymentPeriod)
                .HasForeignKey<CollaboratorPeriod>(
                    e => e.CollaboratorTerminationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => e.CollaboratorId)
                .IsUnique()
                .HasFilter(
                    "\"departure_date\" IS NULL AND \"deleted_at\" IS NULL")
                .HasDatabaseName(
                    "ux_employment_periods_collaborator_active");

            //Codigo debe ser unico por colaborador
            builder.HasIndex(e => e.CollaboratorCode)
                    .IsUnique()
                    .HasFilter("\"deleted_at\" IS NULL")
                    .HasDatabaseName("ux_employment_periods_collaborator_code");

            builder.HasIndex(e => new
                {
                    e.CollaboratorId,
                    e.EntryDate,
                    e.DepartureDate
                })
                .HasDatabaseName(
                    "ix_employment_periods_collaborator_dates");

            builder.HasIndex(e => e.CollaboratorTerminationId)
                .IsUnique()
                .HasFilter(
                    "\"collaborator_termination_id\" IS NOT NULL AND \"deleted_at\" IS NULL")
                .HasDatabaseName(
                    "ux_employment_periods_termination");
        }
    }
}