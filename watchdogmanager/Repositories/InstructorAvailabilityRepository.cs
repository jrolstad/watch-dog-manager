using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.Models;
using watchdogmanager.Services;

namespace watchdogmanager.Repositories
{
    public class InstructorAvailabilityRepository
    {
        private readonly CosmosDbService _cosmosDbService;

        public static string DatabaseId = "WatchDogManager";
        public static string CollectionId = "InstructorAvailability";
        public static string PartitionKey = "Default";

        public InstructorAvailabilityRepository(CosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        public IEnumerable<InstructorAvailability> Get()
        {
            var results = _cosmosDbService.Read<InstructorAvailability>(DatabaseId, CollectionId);

            return results;
        }

        public Task<InstructorAvailability> Get(string id)
        {
            var item = _cosmosDbService.Get<InstructorAvailability>(id, DatabaseId, CollectionId, PartitionKey);

            return item;
        }

        public Task<InstructorAvailability> Save(InstructorAvailability toSave)
        {
            toSave.Area = PartitionKey;
            var result = _cosmosDbService.Save(toSave, DatabaseId, CollectionId);

            return result;
        }

        public Task Delete(string id)
        {
            var result = _cosmosDbService.Delete<InstructorAvailability>(id, DatabaseId, CollectionId, PartitionKey);

            return result;
        }
    }
}
