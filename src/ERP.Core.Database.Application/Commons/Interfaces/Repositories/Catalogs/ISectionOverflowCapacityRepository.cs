using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface ISectionOverflowCapacityRepository : IRepository<SectionOverflowCapacity>
    {
        Task<SectionOverflowCapacity> RegisterSectionOverflowCapacity(SectionOverflowCapacity payload);
    }
}