using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface ISectionPositionsRepository : IRepository<SectionPositions>
    {
        Task<SectionPositions> RegisterPosition(SectionPositions payload);
    }
}