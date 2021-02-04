using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Settings;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using watchdogmanager.functions.Configuration;

[assembly: FunctionsStartup(typeof(watchdogmanager.functions.Startup))]

namespace watchdogmanager.functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureSwagger(builder);
            DependencyInjectionConfiguration.Configure(builder.Services);
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var context = builder.GetContext();

            builder.ConfigurationBuilder
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, "appsettings.json"), optional: true, reloadOnChange: false)
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"appsettings.{context.EnvironmentName}.json"), optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
        }

        private static void ConfigureSwagger(IFunctionsHostBuilder builder)
        {
            builder.AddSwashBuckle(Assembly.GetExecutingAssembly(), options =>
            {
                options.SpecVersion = OpenApiSpecVersion.OpenApi2_0;
                options.AddCodeParameter = true;
                options.PrependOperationWithRoutePrefix = true;
                options.Documents = new[]
                {
                    new SwaggerDocument
                    {
                        Title = "Watch Dog Manager",
                        Description = "Watch Dog Manager APIs",
                        Version = "v1"
                    }
                };

                options.Title = "Identity Extensions APIs";

                options.ConfigureSwaggerGen = x =>
                {
                    x.CustomOperationIds(apiDesc =>
                    {
                        return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)
                            ? methodInfo.Name
                            : default(Guid).ToString();
                    });
                };
            });
        }
    }
}
