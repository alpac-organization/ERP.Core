namespace ERP.Core.Database.Application.Commons.Interfaces.Services
{
    public interface ICodeGenerator
    {
        public string GenerateModuleCode(string subject);
        
        public string GenerateUsername(string subject);

        Task<(bool IsSuccess, string Code)> GenerateUniqueCodeToQuotes(Guid branchId);
    }
}