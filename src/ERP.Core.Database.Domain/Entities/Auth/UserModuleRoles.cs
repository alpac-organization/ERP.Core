using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Auth
{
    public class UserModuleRoles : BaseEntity<Guid>
    {
        public Guid RoleId { get; set; }
        public Guid UserProfileId { get; set; }
        public Guid ModuleId { get; set; }
        
        public bool IsActive { get; set; }
        public string? ModuleCode { get; set; }

        public virtual Role Role { get; set; } = default!;
        public virtual Module Module { get; set; } = default!;
        public virtual UserProfile UserProfile { get; set; } = default!;
    }
}
