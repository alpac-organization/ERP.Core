using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IWorkflowStepDefinitionsRepository : IRepository<WorkflowStepDefinition>
{
    Task<WorkflowStepDefinition> GetFirstStep(WorkflowStepDefinition payload);
    
    Task<WorkflowStepDefinition> GetFirstCode(WorkflowStepDefinition payload);
    
    Task<IEnumerable<WorkflowStepDefinition>> GetAllSteps(WorkflowStepDefinition payload);
}