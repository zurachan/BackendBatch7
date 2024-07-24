using BackendBatch7.API.Configurations;
using BackendBatch7.API.Services;
using StackExchange.Redis;

namespace BackendBatch7.API.Installers
{
    public class CacheInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var redisConfig = new RedisConfiguration();
            configuration.GetSection("RedisConfiguration").Bind(redisConfig);
            services.AddSingleton(redisConfig);
            if (!redisConfig.Enabled) return;
            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConfig.ConnectionString));
            services.AddStackExchangeRedisCache(op => op.Configuration = redisConfig.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}
