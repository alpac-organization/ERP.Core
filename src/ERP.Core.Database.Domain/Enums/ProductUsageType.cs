namespace ERP.Core.Database.Domain.Enums
{
    /// <summary>
    /// Defines the purpose for which a product is used within the company's internal operations.
    /// </summary>
    public enum ProductUsageType
    {
        /// <summary>
        /// The product is consumed or used up in internal processes (e.g. packaging material, office supplies).
        /// </summary>
        Insumo = 1,

        /// <summary>
        /// The product is used as a tool or asset in the operation (e.g. equipment, uniforms, PPE).
        /// </summary>
        OperationalUse = 2
    }
}
