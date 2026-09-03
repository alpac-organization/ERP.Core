using ERP.Core.Database.Domain.Enums;

namespace ERP.Core.Database.Domain.Entities.Bases
{
    /// <summary>
    /// Clase abstracta para mepeo de información compania
    /// </summary>
    public class CompanyInformation
    {
        public string? Ruc { get; set; }
        public string? Code { get; set; }
        public string? Alias { get; set; }
        public string? CompanyName { get; set; }

        public string? ImageUrl { get; set; }
        public string? NeutralImageUrl { get; set; }
    }


    /// <summary>
    /// Entidad de area de trabajo 
    /// </summary>
    public class WorkAreaInformation
    {
        public Guid WorkAreaId { get; set; }
        public int WorkAreaCode { get; set; }
        public string? Description { get; set; }
        public string? WorkAreaName { get; set; }

        public List<CostCenterInformation> CostCenters { get; set; } = [];
    }

    /// <summary>
    /// Entidad de centros de costos
    /// </summary>
    public class CostCenterInformation
    {
        public Guid CostCenterId { get; set; }
        public string? Description { get; set; }
        public string? CostCenterName { get; set; }
        public int CoilCode { get; set; }
        public int CostCenterCode { get; set; }
    }
}