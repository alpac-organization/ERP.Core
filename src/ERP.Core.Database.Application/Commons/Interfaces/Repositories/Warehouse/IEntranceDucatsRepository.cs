using ERP.Core.Database.Domain.Entities.Warehouse;
using ERP.Core.Database.Application.Commons.Interfaces;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IEntranceDucatsRepository : IRepository<EntranceDucats>
{
    Task<EntranceDucats> InsertEntranceDucat(EntranceDucats entranceDucats);
    Task InsertEntranceDucatsRange(IEnumerable<EntranceDucats> entranceDucats);
}