using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using watchdogplatform.core.Managers;
using watchdogplatform.core.Repositories;
using watchdogplatform.entityframework;

namespace watchdogplatform.functions.Application
{
    public static class DependencyInjectionConfig
    {
        public static void Configure(IServiceCollection builderServices)
        {
            builderServices.AddHttpContextAccessor();

            builderServices.AddTransient<HealthManager>();

            builderServices.AddTransient<OrganizationManager>();
            builderServices.AddTransient<OrganizationRepository>();

            builderServices.AddTransient(c =>
            {
                var context = c.GetService<IHttpContextAccessor>();
                var principal = context?.HttpContext?.User;
                return new UserManager(principal);
            });

            builderServices.AddDbContext<WatchDogPlatformDbContext>((provider, builder) =>
            {
                var configuration = provider.GetService<IConfiguration>();
                var accountEndpoint = configuration["WatchDogPlatformDb:Endpoint"];
                var accountKey = configuration["WatchDogPlatformDb:AccountKey"];
                var databaseName = configuration["WatchDogPlatformDb:DatabaseName"];

                builder.UseCosmos(accountEndpoint, accountKey, databaseName);

            });

        }
    }
}