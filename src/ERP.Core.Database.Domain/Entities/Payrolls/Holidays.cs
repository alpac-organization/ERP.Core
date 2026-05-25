using ERP.Core.Database.Domain.Entities.Bases;


namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class Holidays : BaseEntity<Guid>
    {
        public Guid? BranchId { get; set; }
        public string? HolidayName { get; set; }
        public string? Description { get; set; }
        
        public int Day { get; set; }
        public int Month { get; set; }

        public bool IsGlobal { get; set; }
        public bool IsActive { get; set; }
    }
}
