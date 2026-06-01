using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    /// <summary>
    /// Repository responsible for managing operations related to job positions
    /// within the organizational structure.
    /// 
    /// Job positions define the roles, responsibilities, and hierarchical
    /// assignments used across the ERP and payroll modules.
    /// </summary>
    public interface IJobPositionsRepository : IRepository<CostCenter>
    {
        /// <summary>
        /// Registers a new job position in the system.
        /// </summary>
        /// <param name="payload">
        /// Job position entity containing the information to be persisted.
        /// </param>
        /// <returns>
        /// The registered <see cref="JobPosition"/> entity with persisted data.
        /// </returns>
        Task<JobPosition> RegisterJobPosition(JobPosition payload);
    }
}