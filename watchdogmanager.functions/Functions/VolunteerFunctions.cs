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
    public class VolunteerFunctions
    {
        private readonly AuthorizationManager _authorizationManager;
        private readonly VolunteerManager _manager;

        public VolunteerFunctions(AuthorizationManager authorizationManager, VolunteerManager manager)
        {
            _authorizationManager = authorizationManager;
            _manager = manager;
        }

        [FunctionName("volunteer-list")]
        [ProducesResponseType(typeof(IEnumerable<Volunteer>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> List(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "volunteer/{organizationId}")] HttpRequest req,
            string organizationId,
            ILogger log)
        {
            if (!_authorizationManager.CanManageVolunteers(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var result = _manager.GetByOrganization(organizationId);

            return new OkObjectResult(result);
        }

        [FunctionName("volunteer-get")]
        [ProducesResponseType(typeof(Volunteer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "volunteer/{organizationId}/{id}")] HttpRequest req,
            ILogger log,
            string organizationId,
            string id)
        {
            if (!_authorizationManager.CanManageVolunteers(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var result = await _manager.GetById(organizationId, id);

            return new OkObjectResult(result);
        }

        [FunctionName("volunteer-post")]
        [ProducesResponseType(typeof(Volunteer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "volunteer/{organizationId}")]
            [RequestBodyType(typeof(Volunteer),"Volunteer")]HttpRequest req,
            string organizationId,
            ILogger log)
        {
            if (!_authorizationManager.CanManageVolunteers(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var data = req.Content<Volunteer>();
            var result = await _manager.Add(organizationId, data);

            return new OkObjectResult(result);
        }

        [FunctionName("volunteer-put")]
        [ProducesResponseType(typeof(Volunteer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "volunteer/{organizationId}/{id}")]
            [RequestBodyType(typeof(Volunteer),"Volunteer")]HttpRequest req,
            ILogger log,
            string organizationId,
            string id)
        {
            if (!_authorizationManager.CanManageVolunteers(req.HttpContext.User,organizationId)) return new UnauthorizedResult();

            var data = req.Content<Volunteer>();
            var result = await _manager.Update(organizationId, id, data);

            return new OkObjectResult(result);
        }

        [FunctionName("volunteer-delete")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(
           [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "volunteer/{organizationId}/{id}")] HttpRequest req,
           ILogger log,
           string organizationId,
           string id)
        {
            if (!_authorizationManager.CanManageVolunteers(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            await _manager.Delete(organizationId, id);

            return new OkResult();
        }
    }
}
