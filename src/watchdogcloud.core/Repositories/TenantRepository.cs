using watchdogcloud.core.Mappers;
using watchdogcloud.core.Models;
using watchdogcloud.core.Services;

namespace watchdogcloud.core.Repositories
{
    public class TenantRepository
    {
        private static string collectionName = "tenants";
        private static string partitionKey = "default";

        private readonly CosmosDbService cosmosDb;
        private readonly TenantMapper mapper;

        public TenantRepository(CosmosDbService cosmosDb, TenantMapper mapper)
        {
            this.cosmosDb = cosmosDb;
            this.mapper = mapper;
        }
        public List<Tenant> Get() 
        {
            return cosmosDb
                .Query<TenantData>(collectionName)
                .Select(mapper.Map)
                .ToList();
        }

        public async Task<Tenant> Get(string id) 
        {
            var result = await cosmosDb.Get<TenantData>(id, collectionName, partitionKey);
            return mapper.Map(result);
        }

        public async Task<Tenant> Create(Tenant toCreate)
        {
            var data = mapper.Map(toCreate, partitionKey);
            var result = await cosmosDb.Save(data, collectionName, partitionKey);

            return mapper.Map(result);
        }

        public async Task<Tenant> Update(Tenant toUpdate)
        {
            var data = mapper.Map(toUpdate, partitionKey);
            var result = await cosmosDb.Save(data, collectionName, partitionKey);

            return mapper.Map(result);
        }

        public Task Delete(string id)
        {
            return cosmosDb.Delete<Tenant>(id, collectionName, partitionKey);
        }
    }
}
