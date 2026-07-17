using ERP.Core.Database.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Warehouse;

public class StepExecutionLogsConfiguration : IEntityTypeConfiguration<StepExecutionLogs>
{
    public void Configure(EntityTypeBuilder<StepExecutionLogs> builder)
    {
        builder.ToTable("step_execution_logs");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("step_execution_logs_id")
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(e => e.RecordEntranceId)
            .HasColumnName("record_entrance_id")
            .IsRequired();
        
        builder.Property(e => e.WorkflowStepDefinitionCode)
            .HasColumnName("workflow_step_definition_code")
            .IsRequired();
        
        builder.Property(e => e.StartDate)
            .HasColumnName("start_date")
            .HasColumnType("date")
            .IsRequired();
        
        builder.Property(e => e.StartTime)
            .HasColumnName("start_time")
            .IsRequired();
        
        builder.Property(e => e.EndDate)
            .HasColumnName("end_date")
            .HasColumnType("date")
            .IsRequired(false);
        
        builder.Property(e => e.EndTime)
            .HasColumnName("end_time")
            .IsRequired(false);
        
        builder.Property(e => e.ProcessedByUserId)
            .HasColumnName("processed_by_user_id")
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");


        builder.HasOne(e => e.RecordEntrance)
            .WithMany(e => e.ExecutionLogs)
            .HasForeignKey(e => e.RecordEntranceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.WorkflowStepDefinition)
            .WithMany()
            .HasForeignKey(e => e.WorkflowStepDefinitionCode)
            .HasPrincipalKey(w => w.Code)
            .OnDelete(DeleteBehavior.Restrict);
    }
}