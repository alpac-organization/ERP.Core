using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface ICustomsDeclarationsRepository : IRepository<CustomsDeclarations>
{
        Task<CustomsDeclarations> RegisterCustomsDeclarations(CustomsDeclarations payload);
}