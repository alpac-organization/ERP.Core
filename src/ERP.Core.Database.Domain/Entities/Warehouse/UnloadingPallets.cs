using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class UnloadingPallets : BaseEntity<Guid>
{
    public Guid UnloadingDetailsId { get; set; }
    public PalletType PalletType { get; set; }
    public int Quantity { get; set; }
    public decimal? LenghtMetres { get; set; }
    public decimal? WidthMetres { get; set; }

    public virtual UnloadingDetails UnloadindDetails { get; set; } = null!;
}