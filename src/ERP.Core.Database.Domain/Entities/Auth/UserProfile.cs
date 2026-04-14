using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Auth
{
    // Perfil de usuario ✅
    public class UserProfile : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; } = default!;        
        public virtual Company Company { get; set; } = default!;

        public virtual ICollection<UserModuleRoles> UserModuleRole { get; set; } = []; 
    }
}
