using ERP.Core.Database.Domain.Entities.Warehouse.Managua;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse.Managua;

public interface IManifestCancellationsManaguaRepository : IRepository<ManifestCancellationsManagua>
{
    Task<ManifestCancellationsManagua> GenerateManifestCancellationsManagua(ManifestCancellationsManagua manifest);
}