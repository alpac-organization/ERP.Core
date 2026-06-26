using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;
using ERP.Core.Database.Domain.Entities.Warehouse.Managua;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse.Managua;

public class StepExecutionLogsManaguaRepository(ErpDbContext context)
    : Repository<StepExecutionLogsManagua>(context), IStepExecutionLogsManaguaRepository
{
    public async Task<StepExecutionLogsManagua> InsertExecutionLog(StepExecutionLogsManagua executionLog)
    {
        var recod = await _context.StepExecutionLogsManagua.AddAsync(executionLog);
        return recod.Entity;
    }
}