using BackendBatch7.Domain;

namespace BackendBatch7.Infrastructure.Repositories
{
    public class PermissionRepository(DbFactory dbFactory) : Repository<Permission>(dbFactory), IPermissionRepository
    {
    }
}
