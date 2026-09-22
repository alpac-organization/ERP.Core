namespace ERP.Core.Database.Application.Commons.Interfaces.Services
{
    public record CustomerCodesToRegister(
        string CustomerCode,
        string CustomerCif,
        IReadOnlyList<string> BranchCodes);
}