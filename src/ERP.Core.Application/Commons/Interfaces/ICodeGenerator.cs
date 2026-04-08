namespace ERP.Core.Application.Commons.Interfaces
{
    public interface ICodeGenerator
    {
        public string GenerateModuleCode(string subject);
        
        public string GenerateUsername(string subject);
    }
}