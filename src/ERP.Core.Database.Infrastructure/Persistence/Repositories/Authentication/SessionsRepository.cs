using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Authentication
{
    public class SessionsRepository(ErpDbContext _context): Repository<Session>(_context), ISessionsRepository
    {
        public async Task<Session> CreateNewSession(Session session)
        {
            var sessionCreatedd = await _context.Sessions.AddAsync(session);
            return sessionCreatedd.Entity;
        }
    }
}