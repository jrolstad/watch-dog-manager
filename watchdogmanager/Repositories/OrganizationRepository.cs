using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using watchdogmanager.Models;
using watchdogmanager.Services;

namespace watchdogmanager.Repositories
{
    public class OrganizationRepository
    {
        private readonly CosmosDbService _cosmosDbService;

        public static string DatabaseId = "WatchDogManager";
        public static string CollectionId = "Organizations";
        public static string PartitionKey = "Default";

        public OrganizationRepository(CosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        public IEnumerable<Organization> Get()
        {
            var results = _cosmosDbService.Read<Organization>(DatabaseId, CollectionId);

            return results;
        }

        public Task<Organization> Get(string id)
        {
            var item = _cosmosDbService.Get<Organization>(id, DatabaseId, CollectionId, PartitionKey);

            return item;
        }

        public Task<Organization> Save(Organization toSave)
        {
            toSave.Area = PartitionKey;
            var result = _cosmosDbService.Save(toSave, DatabaseId, CollectionId);

            return result;
        }

        public Task Delete(string id)
        {
            var result = _cosmosDbService.Delete<Organization>(id, DatabaseId, CollectionId, PartitionKey);

            return result;
        }
    }
}
