using Microsoft.Extensions.DependencyInjection;
using watchdogplatform.blazor.Application.ViewModels;
using watchdogplatform.blazor.Data;

namespace watchdogplatform.blazor.Application.DependencyInjection
{
    public class DependencyInjectionConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddSingleton<WeatherForecastService>();
            services.AddTransient<UserViewModel>();
        }
    }
}