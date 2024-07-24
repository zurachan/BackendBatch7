using BackendBatch7.Domain;
using BackendBatch7.Infrastructure;
using BackendBatch7.Infrastructure.Repositories;

namespace BackendBatch7.API.Installers
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        }
    }
}