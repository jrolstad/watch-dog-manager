using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.Models;
using watchdogmanager.Services;

namespace watchdogmanager.Repositories
{
    public class ScheduleTemplateRepository
    {
        private readonly CosmosDbService _cosmosDbService;

        public static string DatabaseId = "WatchDogManager";
        public static string CollectionId = "ScheduleTemplates";
        public static string PartitionKey = "Default";

        public ScheduleTemplateRepository(CosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        public IEnumerable<ScheduleTemplate> Get()
        {
            var results = _cosmosDbService.Read<ScheduleTemplate>(DatabaseId, CollectionId);

            return results;
        }

        public Task<ScheduleTemplate> Get(string id)
        {
            var item = _cosmosDbService.Get<ScheduleTemplate>(id, DatabaseId, CollectionId, PartitionKey);

            return item;
        }

        public Task<ScheduleTemplate> Save(ScheduleTemplate toSave)
        {
            toSave.Area = PartitionKey;
            var result = _cosmosDbService.Save(toSave, DatabaseId, CollectionId);

            return result;
        }

        public Task Delete(string id)
        {
            var result = _cosmosDbService.Delete<ScheduleTemplate>(id, DatabaseId, CollectionId, PartitionKey);

            return result;
        }
    }
}
