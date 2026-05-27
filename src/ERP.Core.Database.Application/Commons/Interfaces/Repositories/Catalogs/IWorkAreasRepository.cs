using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    /// <summary>
    /// Repository responsible for managing operations related to work areas
    /// within the organization structure.
    /// 
    /// This repository provides methods for creating, querying, and managing
    /// organizational work areas or departments used across the ERP system.
    /// </summary>
    public interface IWorkAreasRepository : IRepository<WorkArea>
    {
        /// <summary>
        /// Registers a new work area in the system.
        /// </summary>
        /// <param name="payload">
        /// Work area entity containing the information to be persisted.
        /// </param>
        /// <returns>
        /// The registered <see cref="WorkArea"/> entity with its generated data.
        /// </returns>
        Task<WorkArea> RegisterWorkArea(WorkArea payload);
    }
}