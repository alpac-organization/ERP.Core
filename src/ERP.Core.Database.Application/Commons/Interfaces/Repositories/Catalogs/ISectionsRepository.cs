using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface ISectionsRepository: IRepository<Sections>
    {
        Task<Sections> RegisterSection(Sections payload);
    }
}