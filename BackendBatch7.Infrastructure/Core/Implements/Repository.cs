using BackendBatch7.Domain.Entities;
using BackendBatch7.Infrastructure.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackendBatch7.Infrastructure.Core.Implements
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(IDbFactory dbFactory)
        {
            _context = dbFactory.DbContext;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            if (entity is IAuditEntity auditEntity) auditEntity.CreatedDate = DateTime.UtcNow;
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            var now = DateTime.UtcNow;
            foreach (var entity in entities.OfType<IAuditEntity>())
            {
                entity.CreatedDate = now;
            }
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is IAuditEntity auditEntity) auditEntity.UpdatedDate = DateTime.UtcNow;
            if (entity is IDeleteEntity deleteEntity)
            {
                deleteEntity.IsDeleted = true;
                _dbSet.Update(entity);
            }
            else _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> expression) => await _dbSet.FirstOrDefaultAsync(expression);
        public async Task<T?> FindNoTrackingAsync(Expression<Func<T, bool>> expression) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(expression);
        public async Task<IQueryable<T>> ListAsync(Expression<Func<T, bool>> expression) => await Task.FromResult(_dbSet.Where(expression));
        public async Task<IQueryable<T>> ListNoTrackingAsync(Expression<Func<T, bool>> expression) => await Task.FromResult(_dbSet.AsNoTracking().Where(expression));

        public async Task UpdateAsync(T entity)
        {
            if (entity is IAuditEntity auditEntity) auditEntity.UpdatedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }
    }
}
