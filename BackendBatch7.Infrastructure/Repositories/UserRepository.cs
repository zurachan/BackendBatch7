using BackendBatch7.Domain;

namespace BackendBatch7.Infrastructure.Repositories
{
    public class UserRepository(DbFactory dbFactory) : Repository<User>(dbFactory), IUserRepository
    {
    }
}
