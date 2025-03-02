using BackendBatch7.Domain.Base;
using BackendBatch7.Domain.Entities;
using BackendBatch7.Infrastructure.Core.Interfaces;
using BackendBatch7.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BackendBatch7.Infrastructure.Core.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IDbFactory _dbFactory;
        private readonly IAuditLogRepo _auditLogRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitOfWork(IDbFactory dbFactory, IAuditLogRepo auditLogRepository, IHttpContextAccessor httpContextAccessor)
        {
            _dbFactory = dbFactory;
            _context = _dbFactory.DbContext;
            _auditLogRepository = auditLogRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> CompleteAsync()
        {
            await SaveAuditLogsAsync();
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> ExecuteInTransactionAsync(Func<Task> action)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await action();
                await CompleteAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> action)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var result = await action();
                await CompleteAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public void Dispose() => _dbFactory.Dispose();

        private async Task SaveAuditLogsAsync()
        {
            var auditLogs = new List<AuditLog>();
            var userEmail = GetCurrentUserEmail();

            foreach (var entry in _context.ChangeTracker.Entries())
            {
                if (entry.Entity is not IAuditEntity) continue;

                var changes = entry.Properties
                    .Where(p => p.IsModified && !Equals(p.OriginalValue, p.CurrentValue))
                    .ToDictionary(p => p.Metadata.Name, p => $"Old: {p.OriginalValue} -> New: {p.CurrentValue}");

                var log = new AuditLog
                {
                    UserEmail = userEmail,
                    EntityName = entry.Entity.GetType().Name,
                    Action = entry.State.ToString(),
                    Timestamp = DateTime.UtcNow,
                    Changes = changes.Any() ? string.Join("; ", changes.Select(c => $"{c.Key}: {c.Value}")) : "No Changes"
                };

                auditLogs.Add(log);
            }

            if (auditLogs.Count != 0) await _auditLogRepository.AddRangeAsync(auditLogs);
        }

        private string GetCurrentUserEmail()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            return user?.Identity?.IsAuthenticated == true ? user.Claims.FirstOrDefault(c => c.Type == "Email")?.Value ?? "System" : "System";
        }
    }
}
