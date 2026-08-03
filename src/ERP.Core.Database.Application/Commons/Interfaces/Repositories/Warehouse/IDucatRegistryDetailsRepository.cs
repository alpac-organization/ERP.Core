using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IDucatRegistryDetailsRepository : IRepository<DucatRegistryDetails>
{
        Task<DucatRegistryDetails> RegisterDucatRegistryDetails(DucatRegistryDetails payload);
}