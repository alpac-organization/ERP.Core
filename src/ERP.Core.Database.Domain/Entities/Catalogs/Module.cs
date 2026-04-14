using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs
{
    public class Module: BaseEntity<Guid>
    {
        public bool IsActive { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? ModuleName { get; set; }
        public string? PathRedirect { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<UserModuleRoles> UserModuleRoles { get; set; } = [];
    }
}