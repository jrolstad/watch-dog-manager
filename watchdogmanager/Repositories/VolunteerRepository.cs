using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.Models;
using watchdogmanager.Services;

namespace watchdogmanager.Repositories
{
    public class VolunteerRepository
    {
        private readonly CosmosDbService _cosmosDbService;

        public static string DatabaseId = "WatchDogManager";
        public static string CollectionId = "Volunteers";
        public static string PartitionKey = "Default";

        public VolunteerRepository(CosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        public ICollection<Volunteer> Get()
        {
            var results = _cosmosDbService.Read<Volunteer>(DatabaseId, CollectionId);

            return results.ToList();
        }

        public Task<Volunteer> Get(string id)
        {
            var item = _cosmosDbService.Get<Volunteer>(id, DatabaseId, CollectionId, PartitionKey);

            return item;
        }

        public Task<Volunteer> Save(Volunteer toSave)
        {
            toSave.Area = PartitionKey;
            var result = _cosmosDbService.Save(toSave, DatabaseId, CollectionId);

            return result;
        }

        public Task Delete(string id)
        {
            var result = _cosmosDbService.Delete<Volunteer>(id, DatabaseId, CollectionId, PartitionKey);

            return result;
        }
    }
}
