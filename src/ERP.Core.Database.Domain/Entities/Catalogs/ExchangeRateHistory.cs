using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    // Representa una entidad que registrar historial de tasa de cambio.
    public class ExchangeRateHistory : BaseEntity<Guid>
    {
        public Currency Currency { get; set; }

        public decimal Rate { get; set; }

        public DateOnly EffectiveFrom { get; set; }

        public DateOnly? EffectiveTo { get; set; }
    }
}
