namespace ERP.Core.Infrastructure.Attributes
{
    // Este atributo solo sirve para marcar qué endpoints queremos proteger
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class HasTokenAttribute : Attribute { }
}