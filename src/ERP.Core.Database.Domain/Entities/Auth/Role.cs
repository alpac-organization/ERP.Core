using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Auth
{
    // Entidad Role✅
    public class Role : BaseEntity<Guid>
    {
        public string? RoleName { get; set; }
        public string? Description { get; set; }        
        public RoleType RoleType { get; set; }
        
        public virtual ICollection<Permission> Permissions { get; set; } = [];
        public virtual ICollection<UserModuleRoles> UserModuleRoles { get; set; } = [];
    }
}