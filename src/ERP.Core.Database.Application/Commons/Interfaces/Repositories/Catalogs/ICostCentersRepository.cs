using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    /// <summary>
    /// Repository responsible for managing operations related to company cost centers.
    /// 
    /// Cost centers are used to organize, classify, and track operational
    /// and financial expenses within the organization.
    /// </summary>
    public interface ICostCentersRepository : IRepository<CostCenter>
    {
        /// <summary>
        /// Registers a new cost center in the system.
        /// </summary>
        /// <param name="payload">
        /// Cost center entity containing the information to be stored.
        /// </param>
        /// <returns>
        /// The registered <see cref="CostCenter"/> entity with persisted data.
        /// </returns>
        Task<CostCenter> RegisterCostCenter(CostCenter payload);
    }
}