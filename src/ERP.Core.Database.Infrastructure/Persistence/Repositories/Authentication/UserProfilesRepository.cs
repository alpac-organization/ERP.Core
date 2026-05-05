using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Authentication
{
    public class UserProfilesRepository(ErpDbContext _context): Repository<UserProfile>(_context), IUserProfilesRepository
    {
        public async Task<UserProfile> CreateNewUserProfile(UserProfile profile)
        {
            var entry = await _context.Profiles.AddAsync(profile);
            return entry.Entity;
        }
    }
}