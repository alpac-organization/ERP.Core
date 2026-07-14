using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Warehouse;

public class StepExecutionLogsRepository(ErpDbContext context)
    : Repository<StepExecutionLogs>(context), IStepExecutionLogsRepository
{
    public async Task<StepExecutionLogs> InsertExecutionLog(StepExecutionLogs executionLog)
    {
        var recod = await _context.StepExecutionLogs.AddAsync(executionLog);
        return recod.Entity;
    }
}