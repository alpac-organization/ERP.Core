using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class TypesSubsidy: BaseEntity<Guid>
    {
        public string? Code { get; set; }
        public string? SubsidyName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}