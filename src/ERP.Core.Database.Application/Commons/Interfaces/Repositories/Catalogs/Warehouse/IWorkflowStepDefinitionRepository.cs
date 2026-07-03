using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs.Warehouse;

public interface IWorkflowStepDefinitionRepository : IRepository<WorkflowStepDefinition>
{
    Task<WorkflowStepDefinition> GetWorkflowStepDefinition(WorkflowStepDefinition workflowStep);
}