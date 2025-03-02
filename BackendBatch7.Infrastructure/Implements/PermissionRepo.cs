using BackendBatch7.Domain.Entities;
using BackendBatch7.Infrastructure.Core.Implements;
using BackendBatch7.Infrastructure.Core.Interfaces;
using BackendBatch7.Infrastructure.Interfaces;

namespace BackendBatch7.Infrastructure.Implements
{
    public class PermissionRepo(IDbFactory dbFactory) : Repository<Permission>(dbFactory), IPermissionRepo
    {
    }
}
