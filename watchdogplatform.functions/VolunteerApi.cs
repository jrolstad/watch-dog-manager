using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using watchdogplatform.core.Managers;
using watchdogplatform.core.Models;

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
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", "put", Route = "volunteer")] HttpRequest req,
            ILogger log)
        {
            if (string.Equals(req.Method, HttpMethods.Post, StringComparison.InvariantCultureIgnoreCase))
            {
                var postData = JsonConvert.DeserializeObject<Volunteer>(await req.ReadAsStringAsync());
                var saveResult = await _manager.Save(postData);
                return new OkObjectResult(saveResult);
            }

            var volunteers = await _manager.Get();
            return new OkObjectResult(volunteers);
        }
    }
}
