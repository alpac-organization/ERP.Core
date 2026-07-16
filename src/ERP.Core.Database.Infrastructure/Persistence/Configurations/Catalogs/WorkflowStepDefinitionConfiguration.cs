// using Microsoft.EntityFrameworkCore;
// using ERP.Core.Database.Domain.Entities.Catalogs;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace ERP.Core.Database.Infrastructure.Persistence.Configurations.Catalogs;

// public class WorkflowStepDefinitionConfiguration : IEntityTypeConfiguration<WorkflowStepDefinition>
// {
//     public void Configure(EntityTypeBuilder<WorkflowStepDefinition> builder)
//     {
//         builder.ToTable("workflow_step_definitions");
        
//         builder.HasKey(e => e.Id);

//         builder.Property(e => e.Id)
//             .HasColumnName("id")
//             .ValueGeneratedOnAdd();

//         builder.Property(e => e.Code)
//             .HasColumnName("code")
//             .HasMaxLength(50)
//             .IsRequired();
        
//         builder.HasIndex(e => e.Code)
//             .IsUnique();

//         builder.Property(e => e.Name)
//             .HasColumnName("name")
//             .HasMaxLength(100)
//             .IsRequired();

//         builder.Property(e => e.ExecutionOrder)
//             .HasColumnName("execution_order")
//             .IsRequired();

//         builder.Property(e => e.CreatedAt)
//             .HasColumnName("created_at")
//             .HasDefaultValueSql("CURRENT_TIMESTAMP")
//             .ValueGeneratedOnAdd();

//         builder.Property(e => e.DeletedAt)
//             .HasColumnName("deleted_at");

//         // Configuración de la relación 1 a muchos con el proceso de entrada
//         builder.HasMany(e => e.RecordEntrances)
//             .WithOne(r => r.CurrentStep)
//             .HasForeignKey(r => r.CurrentStepCode)
//             .HasPrincipalKey(w => w.Code)
//             .OnDelete(DeleteBehavior.Restrict);

//     }
// }