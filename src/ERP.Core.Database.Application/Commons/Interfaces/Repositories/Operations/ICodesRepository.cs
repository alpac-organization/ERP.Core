using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations;

public interface ICodesRepository : IRepository<Codes>
{
    Task<Codes> GenerateCode(Codes payload);
}