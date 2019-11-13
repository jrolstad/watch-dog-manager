using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using watchdogplatform.core.Managers;

namespace watchdogplatform.functions
{
    public class UserApi
    {
        private readonly UserManager _manager;

        public UserApi(UserManager manager)
        {
            _manager = manager;
        }

        [FunctionName("api-user")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "user")] HttpRequest req,
            ILogger log)
        {
            var result = await _manager.GetCurrent();

            return new OkObjectResult(result);
        }
    }
}