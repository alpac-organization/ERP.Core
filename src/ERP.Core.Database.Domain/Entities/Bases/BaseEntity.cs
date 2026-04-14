namespace ERP.Core.Database.Domain.Entities.Bases
{
    public abstract class BaseEntity<T> 
    {
        public T? Id { get; set; }
        public DateTime? DeletedAt { get; set; } 
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
    }
}