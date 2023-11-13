using watchdogcloud.core.Models;
using watchdogcloud.core.Services;

namespace watchdogcloud.core.Repositories
{
    public class TenantRepository
    {
        private static string collectionName = "tenants";
        private static string partitionKey = "default";

        private readonly CosmosDbService cosmosDb;

        public TenantRepository(CosmosDbService cosmosDb)
        {
            this.cosmosDb = cosmosDb;
        }
        public List<Tenant> Get() 
        {
            return cosmosDb
                .Query<Tenant>(collectionName)
                .ToList();
        }

        public Tenant Get(string id) 
        {
            return cosmosDb.Get<Tenant>(id, collectionName, partitionKey).Result; 
        }

        public Tenant Create(Tenant toCreate)
        {
            return cosmosDb.Save(toCreate, collectionName, partitionKey).Result;
        }

        public Tenant Update(Tenant toUpdate)
        {
            return cosmosDb.Save(toUpdate, collectionName, partitionKey).Result;
        }

        public void Delete(string id)
        {
            cosmosDb.Delete<Tenant>(id, collectionName, partitionKey);
        }
    }
}
