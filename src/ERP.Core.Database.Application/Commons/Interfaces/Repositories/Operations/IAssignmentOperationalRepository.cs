using ERP.Core.Database.Domain.Entities.Operations;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Operations
{
    public interface IAssignmentOperationalRepository : IRepository<AssignmentOperational>
    {
        Task<AssignmentOperational> RegisterAssignmentOperational(AssignmentOperational payload);
    }
}