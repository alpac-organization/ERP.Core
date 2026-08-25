using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IReassignmentSessionsRepository : IRepository<ReassignmentSessions>
{
    Task<ReassignmentSessions> InsertReassignmentSession(ReassignmentSessions reassignmentSession);
}