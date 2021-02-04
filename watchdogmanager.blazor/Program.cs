using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using watchdogmanager.blazor.Configuration;

namespace watchdogmanager.blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Logging.SetMinimumLevel(LogLevel.Warning);

            DependencyInjectionConfig.Register(builder.Services, builder.Configuration, builder.HostEnvironment.BaseAddress);
            AuthenticationConfig.Register(builder.Services, builder.Configuration);

            await builder.Build().RunAsync();
        }
    }
}
