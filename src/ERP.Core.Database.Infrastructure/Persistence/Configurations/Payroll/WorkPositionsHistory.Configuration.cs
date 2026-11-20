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

            builder.Property(e => e.CostCenterId)
                .HasColumnName("cost_center_id")
                .IsRequired(false);

            builder.Property(e => e.StartDate)
                .HasColumnName("start_date")
                .IsRequired();

            builder.Property(e => e.EndDate)
                .HasColumnName("end_date")
                .IsRequired(false);

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.PersonnelActionRequestId)
                .HasColumnName("personnel_action_request_id");

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

            builder.HasOne(d => d.CostCenter)
                .WithMany()
                .HasForeignKey(d => d.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PersonnelActionRequest)
                .WithMany()
                .HasForeignKey(p => p.PersonnelActionRequestId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(p => p.CollaboratorId)
                .IsUnique()
                .HasFilter("\"is_active\" = true AND \"end_date\" IS NULL AND \"deleted_at\" IS NULL")
                .HasDatabaseName("ux_work_position_histories_collaborator_active");
        }
    }
}