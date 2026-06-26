using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse_MNG;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs.Warehouse_MNG;

public class WorkflowStepDefinitionConfiguration : IEntityTypeConfiguration<WorkflowStepDefinition>
{
    public void Configure(EntityTypeBuilder<WorkflowStepDefinition> builder)
    {
        builder.ToTable("workflow_step_definitions");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("workflow_step_definition_id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Code)
            .HasColumnName("code")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.ExecutionOrder)
            .HasColumnName("execution_order")
            .IsRequired();

        // Configuración de la relación 1 a muchos con el proceso de entrada
        builder.HasMany(e => e.RecordEntrances)
            .WithOne(r => r.CurrentStep)
            .HasForeignKey(r => r.CurrentStepId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}