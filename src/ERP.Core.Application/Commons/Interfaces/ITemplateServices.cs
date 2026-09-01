namespace ERP.Core.Application.Commons.Interfaces
{
    public interface ITemplateServices
    {
        string Render(string templateName, object model);
    }
}
