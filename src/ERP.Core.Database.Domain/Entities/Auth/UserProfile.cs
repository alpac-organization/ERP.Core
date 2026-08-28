using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Auth
{
    // Perfil de usuario ✅
    public class UserProfile : BaseEntity<Guid>
    {
        public bool IsActive { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = default!;

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;

        public Guid AreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;

        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = default!;

        public virtual ICollection<Device> Devices { get; set; } = [];
        public virtual ICollection<UserModuleRoles> UserModuleRole { get; set; } = [];
    }
}
