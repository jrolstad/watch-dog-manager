using watchdogcloud.core.Orchestrators;
using watchdogcloud.core.Repositories;
using watchdogcloud.core.Services;

namespace watchdogcloud.web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void Register(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddTransient<TenantOrchestrator>();
            services.AddTransient<TenantRepository>();
            services.AddTransient<CosmosDbService>();
            services.AddTransient<ICosmosLinqQueryFactory,CosmosLinqQueryFactory>();
        }
    }
}
