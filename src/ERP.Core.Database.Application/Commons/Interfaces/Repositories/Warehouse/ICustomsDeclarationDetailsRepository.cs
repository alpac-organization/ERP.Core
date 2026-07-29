using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface ICustomsDeclarationDetailsRepository : IRepository<CustomsDeclarationDetails>
{
        Task<CustomsDeclarationDetails> RegisterCustomsDeclarationDetails(CustomsDeclarationDetails payload);

}