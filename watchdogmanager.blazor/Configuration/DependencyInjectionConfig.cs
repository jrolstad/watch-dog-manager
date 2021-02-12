using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;
using watchdogmanager.blazor.Services;
namespace watchdogmanager.blazor.Configuration
{
    public class DependencyInjectionConfig
    {
        public static void Register(IServiceCollection services, IConfiguration configuration, string baseAddress)
        {
            services.AddMatBlazor();
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

            RegisterDefaultHttpClient(services, baseAddress);
            RegisterApiHttpClient(services, configuration);

            services.AddTransient<IApiService<Organization>, ApiService<Organization>>();
            services.AddTransient<IApiService<Volunteer>, ApiService<Volunteer>>();
            services.AddTransient<IApiService<Instructor>, ApiService<Instructor>>();

            services.AddSingleton<AppState>();
        }

        private static void RegisterDefaultHttpClient(IServiceCollection services, string baseAddress)
        {
            services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
        }

        private static void RegisterApiHttpClient(IServiceCollection services, IConfiguration configuration)
        {
            var baseAddress = configuration["Api:Url"];
            var permission = configuration["Api:Scope"];


            services.AddHttpClient("ApiAuthenticated", client =>
               client.BaseAddress = new Uri(baseAddress))
                .AddHttpMessageHandler(sp => sp.GetRequiredService<AuthorizationMessageHandler>()
                .ConfigureHandler(new[] { baseAddress }, new[] { permission }));
        }
    }
}
