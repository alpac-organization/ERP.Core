using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IUnloadingCrewAssignmentsRepository : IRepository<UnloadingCrewAssignments>
{
    /// <summary>Inserta la asignación de cuadrilla de descarga de una recepción.</summary>
    /// <param name="crewAssignment">Asignación de cuadrilla a insertar.</param>
    /// <returns>La asignación insertada con su identificador generado.</returns>
    Task<UnloadingCrewAssignments> InsertUnloadingCrewAssignments(UnloadingCrewAssignments crewAssignment);
}