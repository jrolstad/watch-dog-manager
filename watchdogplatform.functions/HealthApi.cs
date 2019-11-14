using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using watchdogplatform.core.Managers;

namespace watchdogplatform.functions
{
    public class HealthApi
    {
        private readonly HealthManager _manager;

        public HealthApi(HealthManager manager)
        {
            _manager = manager;
        }

        [FunctionName("api-health")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "health")] HttpRequest req,
            ILogger log)
        {
            var result = _manager.Get(this.GetType().Assembly);

            return new OkObjectResult(result);
        }
    }
}