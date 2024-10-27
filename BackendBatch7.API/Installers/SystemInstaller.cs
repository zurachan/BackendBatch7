using BackendBatch7.API.Services;
using BackendBatch7.Domain;
using BackendBatch7.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BackendBatch7.API.Installers
{
    public class SystemInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("default"));
            //    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //});

            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=BeBatch7.sqlite"));
            // Add the seeding worker
            services.AddHostedService<SeedingWorker>();

            services.AddScoped<Func<AppDbContext>>((provider) => () => provider.GetService<AppDbContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            services.AddMemoryCache();
        }
    }
}
