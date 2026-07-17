namespace ERP.Core.Database.Domain.Enums
{
    /// <summary>
    /// Representa la magnitud física o naturaleza que clasifica una unidad de medida.
    /// Permite agrupar unidades compatibles entre sí (ej. Kilogramo y Libra son ambas de tipo Weight).
    /// </summary>
    public enum UnitMeasureType
    {
        /// <summary>
        /// Unidades que miden peso o masa (ej. Kilogramo, Libra, Gramo).
        /// </summary>
        Weight = 1,

        /// <summary>
        /// Unidades que miden volumen (ej. Litro, Galón, Mililitro).
        /// </summary>
        Volume = 2,

        /// <summary>
        /// Unidades que miden longitud o distancia (ej. Metro, Centímetro, Pulgada).
        /// </summary>
        Length = 3,

        /// <summary>
        /// Unidades que miden área (ej. Metro cuadrado, Pie cuadrado).
        /// </summary>
        Area = 4,

        /// <summary>
        /// Unidades discretas o de conteo, sin conversión entre sí (ej. Unidad, Caja, Paquete).
        /// </summary>
        Unit = 5,

        /// <summary>
        /// Unidades de tiempo (ej. Hora, Día, Mes), aplicable a servicios o alquileres.
        /// </summary>
        Time = 6
    }
}