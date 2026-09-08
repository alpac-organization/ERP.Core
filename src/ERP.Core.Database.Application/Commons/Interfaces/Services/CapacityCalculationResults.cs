using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Services;

public sealed record CalculateRackResult(RackCapacity? Rack, SectionCapacity? Section, WarehouseCapacity? Warehouse);

public sealed record CalculateLotResult(LotsCapacity? Lot, SectionCapacity? Section, WarehouseCapacity? Warehouse);

public sealed record CalculateSectionResult(SectionCapacity Section, WarehouseCapacity? Warehouse);

public sealed record CalculateWarehouseResult(WarehouseCapacity Warehouse);