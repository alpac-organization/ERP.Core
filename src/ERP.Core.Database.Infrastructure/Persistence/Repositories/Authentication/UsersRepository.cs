using Microsoft.EntityFrameworkCore;
using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Authentication
{
    public class UsersRepository(ErpDbContext _context): Repository<User>(_context), IUsersRepository
    {
        public async Task<User> CreateNewUser(User user)
        {
            var entry = await _context.Users.AddAsync(user);
            return entry.Entity;
        }

        public async Task<IEnumerable<User>> GetActiveUsersByCompany(Guid companyId, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(u => u.UserStatus == UserStatus.Active &&
                    u.Profiles.Any(p => p.CompanyId == companyId && p.IsActive))
                .Include(u => u.Profiles.Where(p => p.CompanyId == companyId && p.IsActive))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}