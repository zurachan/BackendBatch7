using BackendBatch7.Domain;

namespace BackendBatch7.Infrastructure.Repositories
{
    public class DepartmentRepository(DbFactory dbFactory) : Repository<Department>(dbFactory), IDepartmentRepository
    {
    }
}
