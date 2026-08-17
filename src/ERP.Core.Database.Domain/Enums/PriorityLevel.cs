namespace ERP.Core.Database.Domain.Enums
{
    /// <summary>
    /// Defines the urgency level assigned to a request, task, or order.
    /// </summary>
    public enum PriorityLevel
    {
        /// <summary>
        /// Crítica; debe atenderse dentro de 24 horas.
        /// </summary>
        Critica = 1,

        /// <summary>
        /// Imprevisto; debe atenderse dentro de 24 horas.
        /// </summary>
        Imprevisto = 2,

        /// <summary>
        /// Normal; debe atenderse dentro de 8 horas.
        /// </summary>
        Normal = 3,

        /// <summary>
        /// Papelería Impresa; debe atenderse dentro de 15 horas.
        /// </summary>
        PapeleriaImpresa = 4
    }
}