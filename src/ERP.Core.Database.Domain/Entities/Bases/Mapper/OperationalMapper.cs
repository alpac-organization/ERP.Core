namespace ERP.Core.Database.Domain.Entities.Bases.Mapper
{
    public class OperationalServiceInformation
    {
        public string? ServiceCode { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public Guid OperationalServiceId { get; set; }
    }
}