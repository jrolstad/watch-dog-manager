using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using watchdogplatform.core.Managers;
using watchdogplatform.core.Models;

namespace watchdogplatform.functions
{
    public class OrganizationApi
    {
        private readonly OrganizationManager _manager;

        public OrganizationApi(OrganizationManager manager)
        {
            _manager = manager;
        }
        [FunctionName("api-organization")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "put", Route = "organization")] HttpRequest req,
            ILogger log)
        {
            if (string.Equals(req.Method, HttpMethods.Post, StringComparison.InvariantCultureIgnoreCase))
            {
                var postData = JsonConvert.DeserializeObject<Organization>(await req.ReadAsStringAsync());
                var saveResult = await _manager.Save(postData);
                return new OkObjectResult(saveResult);
            }

            var getResult = await _manager.Get();
            return new OkObjectResult(getResult);
        }
    }
}