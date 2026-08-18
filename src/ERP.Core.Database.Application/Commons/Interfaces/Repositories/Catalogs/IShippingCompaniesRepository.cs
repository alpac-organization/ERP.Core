using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    public interface IShippingComapaniesRepository: IRepository<ShippingCompanies>
    {
        Task<ShippingCompanies> RegisterShippingCompany(ShippingCompanies payload);
    }
}