using BackendBatch7.Domain.Entities;
using BackendBatch7.Infrastructure.Core.Implements;
using BackendBatch7.Infrastructure.Core.Interfaces;
using BackendBatch7.Infrastructure.Interfaces;

namespace BackendBatch7.Infrastructure.Implements
{
    public class DepartmentRepo(IDbFactory dbFactory) : Repository<Department>(dbFactory), IDepartmentRepo
    {
    }
}
