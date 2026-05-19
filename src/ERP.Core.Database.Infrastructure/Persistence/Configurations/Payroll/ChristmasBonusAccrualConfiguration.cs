

using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class ChristmasBonusAccrualConfiguration : IEntityTypeConfiguration<ChristmasBonusAccrual>
    {
        public void Configure(EntityTypeBuilder<ChristmasBonusAccrual> builder)
        {
            builder.ToTable("christmas_bonus_accruals");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("christmas_bonus_accrual_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.HasIndex(e => e.CollaboratorId)
                .IsUnique()
                .HasDatabaseName("ix_christmas_bonus_collaborator_id");

            builder.Property(e => e.PayrollId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.BaseSalary)
                .HasColumnName("base_salary")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.EquivalentQuantity)
                .HasColumnName("equivalent_quantity")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.EquivalentQuantityInDollars)
                .HasColumnName("equivalent_quantity_in_dollars")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.ChristmasBonusDays)
                .HasColumnName("christmas_bonus_days")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(d => d.Payroll)
                .WithMany()
                .HasForeignKey(d => d.PayrollId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(c => c.Collaborator)
                .WithMany(s => s.ChristmasBonusAccruals)
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);    
            
        }
    }
}