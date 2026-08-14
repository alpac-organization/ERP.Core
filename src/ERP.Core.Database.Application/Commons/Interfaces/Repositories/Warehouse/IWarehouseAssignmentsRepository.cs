using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IWarehouseAssignmentsRepository : IRepository<WarehouseAssignments>
{
    /// <summary>Inserta una asignación de bodega pendiente de confirmación.</summary>
    /// <param name="assignment">Asignación de bodega a insertar.</param>
    /// <returns>La asignación insertada con su identificador generado.</returns>
    Task<WarehouseAssignments> InsertWarehouseAssignment(WarehouseAssignments assignment);
}