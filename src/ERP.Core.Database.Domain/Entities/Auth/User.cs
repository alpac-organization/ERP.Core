using ERP.Core.Database.Domain.Enums;
using ERP.Core.Database.Domain.Entities.Bases;
using ERP.Core.Database.Domain.Entities.Shopping;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Domain.Entities.Auth
{
    //Entidad Usuario✅
    public class User : BaseEntity<Guid>
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Fullname { get; set; }
        public string? PasswordHash { get; set; }
        public string? IdentificationNumber { get; set; }

        public UserType UserType { get; set; }
        public UserStatus UserStatus { get; set; }

        public Guid AreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; } = default!;

        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; } = default!;

        /// <summary>
        /// Control de registros y sesiones que ha relizado el usuario, para poder llevar un control de auditoría y seguridad de la aplicación.
        /// </summary>
        public virtual ICollection<Session> Sessions { get; set; } = [];
        public virtual ICollection<Supplier> Suppliers { get; set; } = [];
        public virtual ICollection<UserProfile> Profiles { get; set; } = [];

        public virtual ICollection<PurchaseRequest> RevisedPurchaseRequests  { get; set; } = [];
        public virtual ICollection<PurchaseRequest> RegisteredPurchaseRequests  { get; set; } = [];
    }
}
