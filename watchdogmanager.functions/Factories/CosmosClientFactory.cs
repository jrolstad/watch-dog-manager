using Microsoft.Azure.Cosmos;
using System;
using watchdogmanager.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace watchdogmanager.functions.Factories
{
    public class CosmosClientFactory : ICosmosClientFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CosmosClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public CosmosClient Create()
        {
            return _serviceProvider.GetService<CosmosClient>();
        }
    }
}
