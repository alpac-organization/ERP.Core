using ERP.Core.Database.Domain.Entities.Warehouse;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Warehouse;

public interface IUnloadingDetailsRepository : IRepository<UnloadingDetails>
{
    /// <summary>Inserta los detalles de descarga de una recepción.</summary>
    /// <param name="unloadingDetails">Detalles de descarga a insertar.</param>
    /// <returns>Los detalles insertados con su identificador generado.</returns>
    Task<UnloadingDetails> InsertUnloadingDetails(UnloadingDetails unloadingDetails);
}