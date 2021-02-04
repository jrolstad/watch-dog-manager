using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using watchdogmanager.Factories;
using watchdogmanager.functions.Factories;
using watchdogmanager.Managers;
using watchdogmanager.Repositories;
using watchdogmanager.Services;

namespace watchdogmanager.functions.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAuthenticationCore();

            services.AddHttpClient();
            services.AddHttpContextAccessor();

            services.AddTransient<ICosmosClientFactory, CosmosClientFactory>();

            services.AddTransient<AuthorizationManager>();
            services.AddTransient<OrganizationManager>();

            services.AddTransient<OrganizationRepository>();

            services.AddTransient<CosmosDbService>();
            services.AddTransient<ISecretService, SecretService>();

            ConfigureCosmosDb(services);
            ConfigureKeyVault(services);
        }

        private static void ConfigureCosmosDb(IServiceCollection services)
        {
            services.AddTransient(provider =>
            {
                var secretService = provider.GetService<ISecretService>();

                var endpoint = secretService.GetSecret("CosmosDb-Endpoint");
                var key = secretService.GetSecret("CosmosDb-Key");

                return new CosmosClient(endpoint, key);
            });
        }

        private static void ConfigureKeyVault(IServiceCollection services)
        {
            services.AddTransient(provider =>
            {
                var configuration = provider.GetService<IConfiguration>();
                var endpoint = configuration["KeyVault:Endpoint"];

                var endpointUri = new System.Uri(endpoint);
                var credentials = new DefaultAzureCredential();
                return new SecretClient(vaultUri: endpointUri, credential: credentials);
            });
        }
    }
}
