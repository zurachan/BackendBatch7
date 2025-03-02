using BackendBatch7.Infrastructure.Implements;
using BackendBatch7.Infrastructure.Interfaces;

namespace BackendBatch7.API.Installers
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IPermissionRepo, PermissionRepo>();
            services.AddScoped<IAuditLogRepo, AuditLogRepo>();
        }
    }
}