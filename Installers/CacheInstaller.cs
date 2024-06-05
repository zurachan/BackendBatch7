using BackendBatch7.Configuration;
using BackendBatch7.Services;
using StackExchange.Redis;

namespace BackendBatch7.Installers
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
