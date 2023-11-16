using Azure.Identity;
using Microsoft.Azure.Cosmos;
using watchdogcloud.core.Mappers;
using watchdogcloud.core.Orchestrators;
using watchdogcloud.core.Repositories;
using watchdogcloud.core.Services;

namespace watchdogcloud.web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void Register(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddTransient<TenantOrchestrator>();
            services.AddTransient<TenantRepository>();
            services.AddTransient<TenantMapper>();
            
            ConfigureCosmosDb(services);
        }

        private static void ConfigureCosmosDb(IServiceCollection services)
        {
            services.AddScoped(provider =>
            {
                var configuration = provider.GetService<IConfiguration>();
                var endpoint = configuration[ConfigNames.Cosmos.BaseUri];

                return GetCosmosClient(endpoint);
            });

            services.AddTransient(provider =>
            {
                var configuration = provider.GetService<IConfiguration>();
                var client = provider.GetService<CosmosClient>();
                var queryFactory = provider.GetService<ICosmosLinqQueryFactory>();

                return new CosmosDbService(client, configuration[ConfigNames.Cosmos.PrimaryDb], queryFactory);
            });

            services.AddTransient<ICosmosLinqQueryFactory, CosmosLinqQueryFactory>();
        }

        private static CosmosClient GetCosmosClient(string endpoint)
        {
            var options = new CosmosClientOptions
            {
                AllowBulkExecution = true,
                MaxRetryAttemptsOnRateLimitedRequests = 19,
                MaxRetryWaitTimeOnRateLimitedRequests = TimeSpan.FromMinutes(1),
                SerializerOptions = new CosmosSerializationOptions
                {
                    IgnoreNullValues = true
                }
            };

            var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions { ExcludeSharedTokenCacheCredential = true });
            var client = new CosmosClient(endpoint,credential, options);
            return client;
        }
    }
}
