using ERP.Core.Database.Domain.Entities.Catalogs;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Catalogs
{
    /// <summary>
    /// Repository responsible for managing operations related to requisition operational areas permitted.
    /// </summary>
    public interface IRequisitionOperationalAreasPermitedRepository : IRepository<RequisitionOperationalAreasPermited>
    {
        /// <summary>
        /// Registers a new requisition operational area permitted in the system.
        /// </summary>
        /// <param name="payload">
        /// RequisitionOperationalAreasPermited entity containing the information to be persisted.
        /// </param>
        /// <returns>
        /// The registered <see cref="RequisitionOperationalAreasPermited"/> entity with its generated data.
        /// </returns>
        Task<RequisitionOperationalAreasPermited> RegisterRequisitionOperationalAreasPermited(RequisitionOperationalAreasPermited payload);
    }
}
