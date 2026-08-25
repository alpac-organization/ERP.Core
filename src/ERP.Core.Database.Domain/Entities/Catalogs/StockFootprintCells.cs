using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class StockFootprintCells : BaseEntity<Guid>
{
    public Guid StockId { get; set; }
    public virtual Stocks Stock { get; set; } = null!;

    public int RowOffset { get; set; }
    public int ColumnOffset { get; set; }
}