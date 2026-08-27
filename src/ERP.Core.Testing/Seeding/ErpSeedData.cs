using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Testing.Seeding;

/// <summary>
/// "Script" de datos iniciales ficticios generado con Bogus.
/// Contiene las entidades listas para ser persistidas por <see cref="ErpDatabaseSeeder"/>.
/// </summary>
public class ErpSeedData
{
    public List<Company> Companies { get; } = new();
    public List<Branch> Branches { get; } = new();
    public List<WorkArea> WorkAreas { get; } = new();
    public List<User> Users { get; } = new();
    public List<UserProfile> Profiles { get; } = new();
    public List<Notification> Notifications { get; } = new();
    public List<Device> Devices { get; } = new();
}
