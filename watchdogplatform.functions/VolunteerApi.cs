using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using watchdogplatform.core.Managers;

namespace watchdogplatform.functions
{
    public class VolunteerApi
    {
        private readonly VolunteerManager _manager;

        public VolunteerApi(VolunteerManager manager)
        {
            _manager = manager;
        }
        [FunctionName("api-volunteer")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "volunteer")] HttpRequest req,
            ILogger log)
        {
            var result = await _manager.Get();

            return new OkObjectResult(result);
        }
    }
}
