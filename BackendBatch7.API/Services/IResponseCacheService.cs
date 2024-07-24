using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;

namespace BackendBatch7.API.Services
{
    public interface IResponseCacheService
    {
        Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeOut);
        Task<string> GetCacheResponseAsync(string cacheKey);
    }

    public class ResponseCacheService(IDistributedCache distributedCache, IConnectionMultiplexer connectionMultiplexer) : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache = distributedCache;
        private readonly IConnectionMultiplexer _connectionMultiplexer = connectionMultiplexer;

        public async Task<string> GetCacheResponseAsync(string cacheKey)
        {
            var cacheResponse = await _distributedCache.GetStringAsync(cacheKey);
            return string.IsNullOrEmpty(cacheResponse) ? null : cacheResponse;

        }

        public async Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeOut)
        {
            if (response == null) return;
            var serializerResponse = JsonConvert.SerializeObject(response, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            await _distributedCache.SetStringAsync(cacheKey, serializerResponse, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = timeOut
            });
        }
    }
}
