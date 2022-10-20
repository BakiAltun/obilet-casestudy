using Microsoft.Extensions.DependencyInjection;
using OBilet.CaseStudy.ApplicationCore.Interfaces; 

namespace OBilet.CaseStudy.Infrastructure.Services
{
    public static class ManagerExtensions
    {
         
         

        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddSingleton<ICookieManager, CookieManager>();
            services.AddSingleton<ICacheManager, CacheManager>();
            services.AddMemoryCache();
            return services;
        }

    }
}
