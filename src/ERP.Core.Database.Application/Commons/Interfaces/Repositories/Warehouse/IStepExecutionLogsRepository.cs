using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IStepExecutionLogsRepository : IRepository<StepExecutionLogs>
{
    Task<StepExecutionLogs> InsertExecutionLog(StepExecutionLogs executionLog);
}