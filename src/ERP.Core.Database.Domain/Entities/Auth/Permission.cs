using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Auth
{
    //Entidad Permiso ✅
    public class Permission : BaseEntity<Guid>
    {
        public Guid RoleId { get; set; } 
        public string? Description { get; set; }
        public string? PermissionName { get; set; }      
        public PermissionType PermissionType { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}