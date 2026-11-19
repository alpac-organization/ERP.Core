using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls;
using ERP.Core.Database.Domain.Entities.Payrolls;
using ERP.Core.Database.Infrastructure.Persistence.Context;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Payroll
{
   public class CollaboratorTerminationRepository(ErpDbContext _context) : Repository<CollaboratorTermination>(_context), ICollaboratorTerminationRepository
   {
      public async Task<CollaboratorTermination> RegisterTermination(CollaboratorTermination termination)
      {
         var registeredTermination = await _context.CollaboratorTerminations.AddAsync(termination);
         return registeredTermination.Entity;
      }
   }
}