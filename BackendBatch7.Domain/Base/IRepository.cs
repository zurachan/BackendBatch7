using System.Linq.Expressions;

namespace BackendBatch7.Domain
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> List(Expression<Func<T, bool>> expression);
        T? FirstOrDefault(Expression<Func<T, bool>> expression);
    }
}
