using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse.Managua;

public class StepExecutionLogsManaguaConfiguration : IEntityTypeConfiguration<StepExecutionLogsManagua>
{
    public void Configure(EntityTypeBuilder<StepExecutionLogsManagua> builder)
    {
        builder.ToTable("step_execution_logs_managua");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("step_execution_logs_id")
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(e => e.RecordEntranceManaguaId)
            .HasColumnName("record_entrance_id")
            .IsRequired();
        
        builder.Property(e => e.WorkflowStepDefinitionId)
            .HasColumnName("workflow_step_definition_id")
            .IsRequired();
        
        builder.Property(e => e.StartTime)
            .HasColumnName("start_time")
            .IsRequired();
        
        builder.Property(e => e.EndTime)
            .HasColumnName("end_time")
            .IsRequired(false);
        
        builder.Property(e => e.ProcessedByUserId)
            .HasColumnName("processed_by_user_id")
            .HasMaxLength(450)
            .IsRequired();

        builder.HasOne(e => e.RecordEntranceManagua)
            .WithMany(e => e.ExecutionLogs)
            .HasForeignKey(e => e.RecordEntranceManaguaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.WorkflowStepDefinition)
            .WithMany()
            .HasForeignKey(e => e.WorkflowStepDefinitionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}