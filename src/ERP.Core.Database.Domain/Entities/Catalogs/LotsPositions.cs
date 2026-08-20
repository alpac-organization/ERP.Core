using System.Security.Cryptography;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class LotsPositions : BaseEntity<Guid>
{
    public Guid LotId { get; set; }
    public virtual Lots Lot { get; set; } = null!;

    public int RowNumber { get; set; }
    public int ColumnNumber { get; set; }

    public string PositionCode { get; set; } = null!;

    public bool AllowsStacking { get; set; } = true;

    public bool IsOccupied { get; set; } = false;
    public bool IsBlocked { get; set; } = true!;
    public string? BlockReason { get; set; }

    public virtual ICollection<WarehouseAssignments> Assignments { get; set; } = [];
    public virtual Stocks? CurrentStock { get; set; }
}