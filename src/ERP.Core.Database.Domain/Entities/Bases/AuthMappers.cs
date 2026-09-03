using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Bases
{
    /// <summary>
    /// Información de entidades de usuarios
    /// </summary>
    public class UserInformation
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Fullname { get; set; }
        public string? PictureUrl { get; set; }
        public UserStatus UserStatus { get; set; }
        
        public WorkAreaInformation? WorkAreaInformation { get; set; }
    }
}