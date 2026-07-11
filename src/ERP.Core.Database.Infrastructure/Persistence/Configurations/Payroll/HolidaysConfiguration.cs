using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class HolidaysConfiguration : IEntityTypeConfiguration<Holidays>
    {
        public void Configure(EntityTypeBuilder<Holidays> builder)
        {
            builder.ToTable("holidays");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("holiday_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.Id)
                .IsUnique()
                .HasDatabaseName("ix_holiday_id");

            builder.Property(e => e.HolidayName)
                .HasColumnName("holiday_name")
                .IsRequired();

            builder.Property(e => e.BranchId)
                .HasColumnName("branch_id")
                .IsRequired(false);

            builder.Property(e => e.Day)
                .HasColumnName("day")
                .IsRequired();

            builder.Property(e => e.Month)
                .HasColumnName("month")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(e => e.IsGlobal)
                .HasColumnName("is_global")
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