namespace ERP.Core.Database.Domain.Entities.Warehouse.Managua;

public class UnloadingDetailsManagua
{
    // Relación 1:1 - Llave primaria y foránea al mismo tiempo
    public Guid RecordEntranceManaguaId { get; set; }
    public DateTime UnloadingStartTime { get; set; }
    public DateTime? UnloadingEndTime { get; set; }
    public string WarehouseChiefUserId { get; set; } = null!;
    public decimal? PreparedPalletsPerHour { get; set; }

    // Propiedades de navegación
    public virtual RecordEntranceManagua RecordEntranceManagua { get; set; } = null!;
}