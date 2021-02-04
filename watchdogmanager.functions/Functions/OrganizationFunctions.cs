using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using watchdogmanager.Managers;
using System.Collections.Generic;
using System.Net;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using watchdogmanager.functions.Extensions;
using watchdogmanager.Models;

namespace watchdogmanager.functions.Functions
{
    public class OrganizationFunctions
    {
        private readonly AuthorizationManager _authorizationManager;
        private readonly OrganizationManager _manager;

        public OrganizationFunctions(AuthorizationManager authorizationManager, OrganizationManager manager)
        {
            _authorizationManager = authorizationManager;
            _manager = manager;
        }

        [FunctionName("organization-list")]
        [ProducesResponseType(typeof(IEnumerable<Organization>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> List(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "organization")] HttpRequest req,
            ILogger log)
        {
            var result = _manager.Get();

            return new OkObjectResult(result);
        }

        [FunctionName("organization-get")]
        [ProducesResponseType(typeof(Organization), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "organization/{id}")] HttpRequest req,
            ILogger log,
            string id)
        {
            var result = await _manager.Get(id);

            return new OkObjectResult(result);
        }

        [FunctionName("organization-post")]
        [ProducesResponseType(typeof(Organization), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "organization")]
            [RequestBodyType(typeof(Organization),"Organization")]HttpRequest req,
            ILogger log)
        {
            if (!_authorizationManager.CanManageOrganizations(req.HttpContext.User)) return new UnauthorizedResult();

            var data = req.Content<Organization>();
            var result = await _manager.Add(data);

            return new OkObjectResult(result);
        }

        [FunctionName("organization-put")]
        [ProducesResponseType(typeof(Organization), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "organization/{id}")]
            [RequestBodyType(typeof(Organization),"Organization")]HttpRequest req,
            ILogger log,
            string id)
        {
            if (!_authorizationManager.CanManageOrganizations(req.HttpContext.User)) return new UnauthorizedResult();

            var data = req.Content<Organization>();
            var result = await _manager.Update(id, data);

            return new OkObjectResult(result);
        }

        [FunctionName("organization-delete")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(
           [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "organization/{id}")] HttpRequest req,
           ILogger log,
           string id)
        {
            if (!_authorizationManager.CanManageOrganizations(req.HttpContext.User)) return new UnauthorizedResult();

            await _manager.Delete(id);

            return new OkResult();
        }
    }
}
