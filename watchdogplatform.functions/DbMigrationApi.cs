using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using watchdogplatform.entityframework;

namespace watchdogplatform.functions
{
    public class DbMigrationApi
    {
        private readonly WatchDogPlatformDbContext _context;

        public DbMigrationApi(WatchDogPlatformDbContext context)
        {
            _context = context;
        }

        [FunctionName("api-dbmigration")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "dbmigration")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Starting Migration");
            await _context.Database.EnsureCreatedAsync();
            log.LogInformation("Migration Complete");

            return new OkResult();
        }
    }
}