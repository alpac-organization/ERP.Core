using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Authentication;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Authentication
{
    public class DevicesRepository(ErpDbContext _context): Repository<Device>(_context), IDevicesRepository
    {
        public async Task<Device> RegisterDevice(Device payload)
        {
            var record = await _context.Devices.AddAsync(payload);
            return record.Entity;
        }
    }
}