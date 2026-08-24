using ERP.Core.Database.Domain.Entities.Auth;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication
{
    public interface INotificationsRepository : IRepository<Notification>
    {
        public Task<Notification> CreateNotification(Notification payload);
    }
}