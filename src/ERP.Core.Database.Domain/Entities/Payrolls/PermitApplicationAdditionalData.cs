namespace ERP.Core.Database.Domain.Entities.Payrolls
{
    public class PermitApplicationAdditionalData
    {
        public List<PermitEvidenceImage> Images { get; set; } = [];
    }

    public class PermitEvidenceImage
    {
        public Guid ImageId { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public string? ContentBase64 { get; set; }
    }
}
