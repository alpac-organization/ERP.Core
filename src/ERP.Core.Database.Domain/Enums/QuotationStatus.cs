namespace ERP.Core.Database.Domain.Enums
{
    /// <summary>
    /// Represents the current status of a quotation throughout its approval process.
    /// </summary>
    public enum QuotationStatus
    {
        /// <summary>
        /// The quotation has been created and is pending review or approval.
        /// </summary>
        Pending = 1,

        /// <summary>
        /// The quotation has been reviewed and approved.
        /// </summary>
        Approved = 2,

        /// <summary>
        /// The quotation has been canceled and is no longer valid.
        /// </summary>
        Canceled = 3,

        /// <summary>
        /// The quotation has been reviewed and rejected.
        /// </summary>
        Rejected = 4
    }
}