using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System;

namespace watchdogmanager.functions.Functions
{
    public class UserFunctions
    {
        [FunctionName("user-claims")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "user/claims")] HttpRequest req,
            ILogger log)
        {
            try
            {
                if (!req.HttpContext.User?.Identity?.IsAuthenticated ?? false) return new OkObjectResult("Not Authenticated");

                var claims = req.HttpContext.User?.Claims?.Select(c => new KeyValuePair<string, string>(c.Type, c.Value)).ToList();

                return new OkObjectResult(claims);
            }
            catch(Exception ex)
            {
                return new OkObjectResult(ex.ToString());
            }
            
        }
    }
}
