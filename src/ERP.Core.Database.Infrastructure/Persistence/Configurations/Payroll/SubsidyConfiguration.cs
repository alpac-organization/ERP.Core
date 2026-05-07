using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class SubsidyConfiguration : IEntityTypeConfiguration<Subsidy>
    {
        public void Configure(EntityTypeBuilder<Subsidy> builder)
        {
            builder.ToTable("subsidies");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("subsidy_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

             builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.StartDate)
                .HasColumnName("start_date")
                .IsRequired();

            builder.Property(e => e.EndDate)
                .HasColumnName("end_date")
                .IsRequired();

            builder.Property(e => e.ReferenceNumber)
                .HasColumnName("reference_number")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Percentage)
                .HasColumnName("percentage")
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(e => e.SubsidyType)
                .HasColumnName("subsidy_type")
                .IsRequired();

            builder.Property(e => e.Observations)
                .HasColumnName("observations")
                .HasMaxLength(500);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(c => c.Collaborator)
                .WithMany()
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}