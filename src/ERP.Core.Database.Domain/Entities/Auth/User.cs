using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Shopping;

namespace ERP.Core.Database.Domain.Entities.Auth
{
    //Entidad Usuario ✅
    public class User : BaseEntity<Guid>
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Fullname { get; set; }
        public string? PasswordHash { get; set; }
        public string? IdentificationNumber { get; set; }

        public int AreaId { get; set; }

        public UserType UserType { get; set; }
        public UserStatus UserStatus { get; set; }

        public virtual ICollection<Session> Sessions { get; set; } = [];
        public virtual ICollection<UserProfile> Profiles { get; set; } = [];
        public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; } = [];
    }
}
