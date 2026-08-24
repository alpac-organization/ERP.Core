using ERP.Core.Database.Domain.Entities.Auth;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication
{
    public interface IDevicesRepository : IRepository<Device>
    {
        public Task<Device> RegisterDevice(Device payload);
    }
}