using System.Runtime.CompilerServices;
using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class TransportUnit : BaseEntity<Guid>
{
    public string Name {get;set;} = null!;
}