using System.Linq.Expressions;

namespace BackendBatch7.Infrastructure.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IQueryable<T>> ListAsync(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> ListNoTrackingAsync(Expression<Func<T, bool>> expression);
        Task<T?> FindAsync(Expression<Func<T, bool>> expression);
        Task<T?> FindNoTrackingAsync(Expression<Func<T, bool>> expression);
    }
}
