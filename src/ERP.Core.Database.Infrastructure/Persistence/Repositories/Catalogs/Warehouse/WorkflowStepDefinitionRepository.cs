using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs.Warehouse;
using ERP.Core.Database.Domain.Entities.Catalogs.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs.Warehouse;

public class WorkflowStepDefinitionRepository(ErpDbContext _context) : Repository<WorkflowStepDefinition>(_context), IWorkflowStepDefinitionRepository
{
    public async Task<WorkflowStepDefinition> GetWorkflowStepDefinition(WorkflowStepDefinition payload)
    {
        var record = await _context.WorkflowStepDefinitions.AddAsync(payload);
        return record.Entity;
    }
}