using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IStepExecutionLogsManaguaRepository : IRepository<StepExecutionLogsManagua>
{
    Task<StepExecutionLogsManagua> InsertExecutionLog(StepExecutionLogsManagua executionLog);
}