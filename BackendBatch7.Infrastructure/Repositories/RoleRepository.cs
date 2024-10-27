using BackendBatch7.Domain;

namespace BackendBatch7.Infrastructure.Repositories
{
    public class RoleRepository(DbFactory dbFactory) : Repository<Role>(dbFactory), IRoleRepository
    {
    }
}
