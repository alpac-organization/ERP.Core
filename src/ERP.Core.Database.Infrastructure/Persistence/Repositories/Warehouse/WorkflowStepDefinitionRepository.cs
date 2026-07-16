using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class WorkflowStepDefinitionsRepository(ErpDbContext context) : Repository<WorkflowStepDefinition>(context), IWorkflowStepDefinitionsRepository
{
    public async Task<WorkflowStepDefinition> GetFirstStep(WorkflowStepDefinition payload)
    {
        return await _context.WorkflowStepDefinitions
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.ExecutionOrder == 1)
            ?? throw new Exception("No se encontró el paso inicial definido.");

    }
    public async Task<WorkflowStepDefinition> GetFirstCode(WorkflowStepDefinition payload)
    {
        return await _context.WorkflowStepDefinitions
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Code == payload.Code)
            ?? throw new Exception("Código de seguimiento no encontrado.");
    }
    public async Task<IEnumerable<WorkflowStepDefinition>> GetAllSteps(WorkflowStepDefinition payload)
    {
        return await _context.WorkflowStepDefinitions
            .AsNoTracking()
            .OrderBy(s => s.ExecutionOrder)
            .ToListAsync();
    }
}