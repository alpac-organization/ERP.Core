using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class AssistanceControlConfiguration : IEntityTypeConfiguration<AssistanceControl>
    {
        public void Configure(EntityTypeBuilder<AssistanceControl> builder)
        {
            builder.ToTable("assistance_control");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("assistance_control_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.AmountHours)
                .HasColumnName("amount_hours")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.ProfessionalPayrollId)
                .HasColumnName("professioal_payroll_id")
                .IsRequired();

            builder.Property(e => e.ShiftDate)
                .HasColumnName("shift_date")
                .HasColumnType("date")
                .IsRequired();

            // builder.Property(e => e.LocationId)
            //     .HasColumnName("location_id")
            //     .IsRequired();

            // //Relación de las tablas de locations
            // builder.HasOne(d => d.Location)
            //     .WithMany()
            //     .HasForeignKey(d => d.LocationId)
            //     .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");
        }
    }
}