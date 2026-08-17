using ERP.Core.Database.Domain.Entities.Bases;

namespace ERP.Core.Database.Domain.Entities.Catalogs;

public class CustomsBranches : BaseEntity<Guid>
{
    public string Name { get; set; } = null!;
}