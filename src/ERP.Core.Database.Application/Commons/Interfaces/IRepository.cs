using System.Linq.Expressions;

namespace ERP.Core.Database.Application.Commons.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        Task UpdateAsync(T entity);
        Task<List<T>> ToListAsync(IQueryable<T> query, CancellationToken ct);
        Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken ct);
    }
}