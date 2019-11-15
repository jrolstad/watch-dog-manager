using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using watchdogplatform.blazor.Application.Configuration;
using watchdogplatform.blazor.Application.DependencyInjection;

namespace watchdogplatform.blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AuthenticationConfiguration.Configure(services,Configuration);
            BlazorConfiguration.Configure(services);

            DependencyInjectionConfig.Configure(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ApplicationConfiguration.Configure(app,env);
        }
    }
}
