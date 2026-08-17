namespace ERP.Core.Database.Domain.Enums
{
    /// <summary>
    /// Defines the urgency level assigned to a request, task, or order.
    /// </summary>
    public enum PriorityLevel
    {
        /// <summary>
        /// No priority level has been assigned.
        /// </summary>
        None = 0,

        /// <summary>
        /// Critical; must be handled within 24 hours.
        /// </summary>
        Critical = 1,

        /// <summary>
        /// Unforeseen; must be handled within 24 hours.
        /// </summary>
        Unforeseen = 2,

        /// <summary>
        /// Normal; must be handled within 8 hours.
        /// </summary>
        Normal = 3,

        /// <summary>
        /// Printed stationery; must be handled within 15 hours.
        /// </summary>
        PrintedStationery = 4
    }
}