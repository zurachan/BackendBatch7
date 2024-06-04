using BackendBatch7.Domains;
using Microsoft.Extensions.Caching.Memory;

namespace BackendBatch7.Common.Cache
{
    public interface ICacheService<T> where T : class
    {
        List<T> Get(string key);
    }

    public class CacheService<T>(IMemoryCache cache, AppDbContext context) : ICacheService<T> where T : class
    {
        private readonly IMemoryCache _cache = cache;
        private readonly AppDbContext _context = context;

        public List<T> Get(string cacheKey)
        {
            if (!_cache.TryGetValue(cacheKey, out List<T> data))
            {
                data = _context.Set<T>().ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(12),
                    SlidingExpiration = TimeSpan.FromHours(12),
                    Size = 1024,
                };
                _cache.Set(cacheKey, data, cacheEntryOptions);
            }
            return data;
        }
    }
}
