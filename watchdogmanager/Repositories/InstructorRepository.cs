using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.Models;
using watchdogmanager.Services;

namespace watchdogmanager.Repositories
{
    public class InstructorRepository
    {
        private readonly CosmosDbService _cosmosDbService;

        public static string DatabaseId = "WatchDogManager";
        public static string CollectionId = "Instructors";
        public static string PartitionKey = "Default";

        public InstructorRepository(CosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        public IEnumerable<Instructor> Get()
        {
            var results = _cosmosDbService.Read<Instructor>(DatabaseId, CollectionId);

            return results;
        }

        public Task<Instructor> Get(string id)
        {
            var item = _cosmosDbService.Get<Instructor>(id, DatabaseId, CollectionId, PartitionKey);

            return item;
        }

        public Task<Instructor> Save(Instructor toSave)
        {
            toSave.Area = PartitionKey;
            var result = _cosmosDbService.Save(toSave, DatabaseId, CollectionId);

            return result;
        }

        public Task Delete(string id)
        {
            var result = _cosmosDbService.Delete<Instructor>(id, DatabaseId, CollectionId, PartitionKey);

            return result;
        }
    }
}
