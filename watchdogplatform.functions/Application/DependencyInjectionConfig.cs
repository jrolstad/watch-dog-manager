using Microsoft.Extensions.DependencyInjection;
using watchdogplatform.core.Managers;
using watchdogplatform.core.Repositories;

namespace watchdogplatform.functions.Application
{
    public static class DependencyInjectionConfig
    {
        public static void Configure(IServiceCollection builderServices)
        {
            builderServices.AddTransient<VolunteerManager>();
            builderServices.AddTransient<VolunteerRepository>();
            
        }
    }
}