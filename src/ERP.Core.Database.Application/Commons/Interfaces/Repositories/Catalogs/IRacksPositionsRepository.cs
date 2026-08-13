using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

public interface IRackPositionsRepository : IRepository<RackPositions>
{
    Task<RackPositions> RegisterRackPosition(RackPositions payload);
}