using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Warehouse.WarehouseCorinto
{
    public class InboundAppointment : BaseEntity<Guid>
    {
        public int RequestCode { get; set; }
        public string? GeneratedBy { get; set; }
        public DateOnly QrCodeCreationDate { get; set; }
        public AppointmentQrStatus Status { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = default!;
    }
}