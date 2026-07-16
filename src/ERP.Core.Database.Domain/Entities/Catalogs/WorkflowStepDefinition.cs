// using ERP.Core.Database.Domain.Entities.Bases;
// using ERP.Core.Database.Domain.Entities.Warehouse;

// namespace ERP.Core.Database.Domain.Entities.Catalogs;

// public class WorkflowStepDefinition : BaseEntity<Guid>
// {
//     public string Code { get; set; } = null!;
//     public string Name { get; set; } = null!;
//     public int ExecutionOrder { get; set; }

//     // Propiedad inversa para la navegación
//     public virtual ICollection<RecordEntrance> RecordEntrances { get; set; } = [];
// }