using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IPersonnelActionRequestRepository : IRepository<PersonnelActionRequest>
    {
        Task<PersonnelActionRequest> CreatePersonnelActionRequest(PersonnelActionRequest payload);
    }
}
