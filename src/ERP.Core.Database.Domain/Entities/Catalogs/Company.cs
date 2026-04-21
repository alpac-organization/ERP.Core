
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class Company : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Code { get; set; }
        public string? Alias { get; set; }
        public string? ImageUrl { get; set; }
        public string? NeutralImageUrl { get; set; }
        public string? CompanieName { get; set; }
        

        public virtual ICollection<Branch> Branches { get; set; } = [];
        public virtual ICollection<Catalog> Catalogs { get; set; } = [];
        public virtual ICollection<Payroll> Payrolls { get; set; } = [];
        public virtual ICollection<Collaborator> Collaborators { get; set; } = [];
    }
}