using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IDiscrepanciesManaguaRepository : IRepository<DiscrepanciesManagua>
{
    Task<DiscrepanciesManagua> RegisterDiscrepanciesManagua(DiscrepanciesManagua discrepancies);
}