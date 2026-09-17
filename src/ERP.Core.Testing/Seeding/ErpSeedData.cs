using ERP.Core.Database.Domain.Entities.Auth;
using ERP.Core.Database.Domain.Entities.Catalogs;
using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Testing.Seeding;

/// <summary>
/// "Script" de datos iniciales ficticios generado con Bogus.
/// Contiene las entidades listas para ser persistidas por <see cref="ErpDatabaseSeeder"/>.
/// </summary>
public class ErpSeedData
{
    #region Catalogos
    public List<Company> Companies { get; }  = [];
    public List<Branch> Branches { get; }    = [];
    public List<WorkArea> WorkAreas { get; } = [];
    public List<Module> Modules {get;}       = [];   

    #endregion

    
    #region Autenticación
    public List<User> Users { get; }           = [];
    public List<UserProfile> Profiles { get; } = [];
    public List<Device> Devices { get; }       = [];
    public List<Notification> Notifications { get; } = [];
    public List<Role> Roles {get;} = []; 

    #endregion 

    #region Almacenes
    public List<Warehouses> Warehouses {get;} = [];
    public List<WarehouseCapacity> WarehouseCapacities {get;} = [];
    public List<Sections> Sections {get;} = [];
    public List<SectionCapacity> SectionCapacities {get;} = [];
    #endregion
}
