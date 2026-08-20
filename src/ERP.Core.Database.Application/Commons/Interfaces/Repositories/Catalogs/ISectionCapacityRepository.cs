using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface ISectionCapacityRepository: IRepository<SectionCapacity>
    {
        Task<SectionCapacity> RegisterSectionCapacity(SectionCapacity payload);
    }
}