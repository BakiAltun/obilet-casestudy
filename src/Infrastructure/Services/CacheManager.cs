using Microsoft.Extensions.Caching.Memory;
using OBilet.CaseStudy.ApplicationCore.Interfaces;
using System; 

namespace OBilet.CaseStudy.Infrastructure.Services
{
    public class CacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public CacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T GetOrCreate<T>(Func<T> get) where T : class
        {
            return _memoryCache.GetOrCreate(typeof(T).Name, entry =>
           {
               entry.SlidingExpiration = TimeSpan.FromMinutes(30);
               return get.Invoke();
           });
        }
    }
}
