using watchdogmanager.Factories;
using Microsoft.Azure.Cosmos;
using System.Linq;
using System.Threading.Tasks;

namespace watchdogmanager.Services
{
    public class CosmosDbService
    {
        private readonly ICosmosClientFactory _cosmosClientFactory;

        public CosmosDbService(ICosmosClientFactory cosmosClientFactory)
        {
            _cosmosClientFactory = cosmosClientFactory;
        }

        public IQueryable<T> Read<T>(string databaseId, string collectionId)
        {
            var client = _cosmosClientFactory.Create();

            var result = client.GetContainer(databaseId, collectionId)
                .GetItemLinqQueryable<T>(allowSynchronousQueryExecution: true);

            return result;
        }

        public async Task<T> Get<T>(string id, string databaseId, string collectionId, string partitionKey)
        {
            var client = _cosmosClientFactory.Create();
            var result = await client.GetContainer(databaseId, collectionId)
                .ReadItemAsync<T>(id, new PartitionKey(partitionKey));

            return result.Resource;
        }

        public async Task<T> Save<T>(T toSave, string databaseId, string collectionId)
        {
            var client = _cosmosClientFactory.Create();
            var result = await client.GetContainer(databaseId, collectionId)
                .UpsertItemAsync(toSave);

            return result.Resource;
        }

        public async Task<T> Delete<T>(string id, string databaseId, string collectionId, string partitionKey)
        {
            var client = _cosmosClientFactory.Create();
            var result = await client.GetContainer(databaseId, collectionId)
                .DeleteItemAsync<T>(id, new PartitionKey(partitionKey));

            return result.Resource;
        }
    }
}
