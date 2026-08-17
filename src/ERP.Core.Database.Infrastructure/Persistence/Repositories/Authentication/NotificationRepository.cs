using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Authentication
{
    public class NotificationsRepository(ErpDbContext _context): Repository<Notification>(_context), INotificationsRepository
    {
        public async Task<Notification> CreateNotification(Notification payload)
        {
            var record = await _context.Notifications.AddAsync(payload);
            return record.Entity;
        }
    }
}