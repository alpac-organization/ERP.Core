using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse.WarehouseCorinto;

namespace ERP.Core.Database.Domain.Entities.Warehouse;

public class Customer : BaseEntity<Guid>
{
    public string? DNI_RUC {get; set;}
    public string? LegalName {get; set;}
    public bool IsActive {get; set;} = true;
    public string? PictureUrl { get; set; }

    public Guid CustomerTypeId {get; set;}
    public virtual CustomerType CustomerType {get; set;} = default!;

    public virtual ICollection<Product> Products { get; set; } = [];

    //Codigos QR Generados para que este cliente acceda.
    public virtual ICollection<InboundAppointment> InboundAppointments { get; set; } = [];
}