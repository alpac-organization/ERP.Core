using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Infrastructure.Persistence.Context;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs;

namespace ERP.Core.Database.Infrastructure.Persistence.Repositories.Catalogs;

public class EquipmentRepository(ErpDbContext _context) : Repository<Equipment>(_context), IEquipmentRepository
{
    public async Task<Equipment> RegisterEquipment(Equipment payload)
    {
        await _context.Equipments.AddAsync(payload);
        return payload;
    }
}