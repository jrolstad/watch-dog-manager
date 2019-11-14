using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using watchdogplatform.core.Managers;
using watchdogplatform.core.Repositories;

namespace watchdogplatform.functions.Application
{
    public static class DependencyInjectionConfig
    {
        public static void Configure(IServiceCollection builderServices)
        {
            builderServices.AddHttpContextAccessor();

            builderServices.AddTransient<VolunteerManager>();
            builderServices.AddTransient<VolunteerRepository>();

            builderServices.AddTransient<HealthManager>();

            builderServices.AddTransient<OrganizationManager>();
            builderServices.AddTransient<OrganizationRepository>();

            builderServices.AddTransient(c =>
            {
                var context = c.GetService<IHttpContextAccessor>();
                var principal = context?.HttpContext?.User;
                return new UserManager(principal);
            });

        }
    }
}