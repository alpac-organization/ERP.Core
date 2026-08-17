namespace ERP.Core.Database.Domain.Enums
{
    /// <summary>
    /// Defines the urgency level assigned to a request, task, or order.
    /// </summary>
    public enum PriorityLevel
    {
        /// <summary>
        /// Low priority; can be handled without immediate attention.
        /// </summary>
        Low = 1,

        /// <summary>
        /// Standard priority; normal handling timeline.
        /// </summary>
        Medium = 2,

        /// <summary>
        /// High priority; should be handled ahead of standard items.
        /// </summary>
        High = 3,

        /// <summary>
        /// Urgent; requires immediate attention.
        /// </summary>
        Urgent = 4
    }
}