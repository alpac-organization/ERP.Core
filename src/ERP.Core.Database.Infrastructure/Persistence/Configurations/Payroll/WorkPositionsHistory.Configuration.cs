using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Entities.Payrolls;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Payroll
{
    public class WorkPositionsHistoryConfiguration : IEntityTypeConfiguration<WorkPositionHistory>
    {
        public void Configure(EntityTypeBuilder<WorkPositionHistory> builder)
        {
            builder.ToTable("work_position_histories");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("work_position_history_id")
                .HasDefaultValueSql("gen_random_uuid()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.WorkPositionId)
                .HasColumnName("work_position_id")
                .IsRequired();
                
            builder.Property(e => e.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(e => e.JobPositionId)
                .HasColumnName("job_position_id")
                .IsRequired();

            builder.Property(e => e.StartDate)
                .HasColumnName("start_date")
                .IsRequired();

            builder.Property(e => e.EndDate)
                .HasColumnName("end_date")
                .IsRequired(false);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            builder.HasOne(c => c.Collaborator)
                .WithMany(s => s.WorkPositionHistory)
                .HasForeignKey(s => s.CollaboratorId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(d => d.WorkPosition)
                .WithMany()
                .HasForeignKey(d => d.WorkPositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}