using BackendBatch7.Infrastructure.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendBatch7.Infrastructure.Core.Implements;

public class DbFactory : IDbFactory
{
    private bool _disposed = false;
    private Func<AppDbContext> _instanceFunc;
    private DbContext _dbContext;

    public DbContext DbContext => _dbContext ??= _instanceFunc.Invoke();

    public DbFactory(Func<AppDbContext> dbContextFactory)
    {
        _instanceFunc = dbContextFactory;
    }

    public void Dispose()
    {
        if (!_disposed && _dbContext != null)
        {
            _disposed = true;
            _dbContext.Dispose();
        }
    }
}
