using Microsoft.EntityFrameworkCore;

namespace BackendBatch7.Infrastructure.Core.Interfaces;

public interface IDbFactory : IDisposable
{
    DbContext DbContext { get; }
}
