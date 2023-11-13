using watchdogcloud.core.Orchestrators;

namespace watchdogcloud.web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void Register(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddTransient<TenantOrchestrator>();
        }
    }
}
