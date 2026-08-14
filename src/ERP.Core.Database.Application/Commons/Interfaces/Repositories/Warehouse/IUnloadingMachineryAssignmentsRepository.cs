using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IUnloadingMachineryAssignmentsRepository : IRepository<UnloadingMachineryAssignments>
{
    /// <summary>Inserta la asignación de maquinaria de descarga de una recepción.</summary>
    /// <param name="machineryAssignment">Asignación de maquinaria a insertar.</param>
    /// <returns>La asignación insertada con su identificador generado.</returns>
    Task<UnloadingMachineryAssignments> InsertUnloadingMachineryAssignments(UnloadingMachineryAssignments machineryAssignment);
}