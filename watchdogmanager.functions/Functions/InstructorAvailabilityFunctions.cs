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
    public class InstructorAvailabilityFunctions
    {
        private readonly AuthorizationManager _authorizationManager;
        private readonly InstructorAvailabilityManager _manager;

        public InstructorAvailabilityFunctions(AuthorizationManager authorizationManager, InstructorAvailabilityManager manager)
        {
            _authorizationManager = authorizationManager;
            _manager = manager;
        }

        [FunctionName("instructoravailability-list")]
        [ProducesResponseType(typeof(IEnumerable<InstructorAvailability>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> List(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "instructoravailability/{organizationId}")] HttpRequest req,
            string organizationId,
            ILogger log)
        {
            if (!_authorizationManager.CanManageInstructors(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var result = _manager.GetByOrganization(organizationId);

            return new OkObjectResult(result);
        }

        [FunctionName("instructoravailability-get")]
        [ProducesResponseType(typeof(InstructorAvailability), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "instructoravailability/{organizationId}/{id}")] HttpRequest req,
            ILogger log,
            string organizationId,
            string id)
        {
            if (!_authorizationManager.CanManageInstructors(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var result = _manager.GetByInstructor(organizationId, id);

            return new OkObjectResult(result);
        }

        [FunctionName("instructoravailability-post")]
        [ProducesResponseType(typeof(InstructorAvailability), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "instructoravailability/{organizationId}")]
            [RequestBodyType(typeof(InstructorAvailability),"Instructor")]HttpRequest req,
            string organizationId,
            ILogger log)
        {
            if (!_authorizationManager.CanManageInstructors(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var data = req.Content<InstructorAvailability>();
            var result = await _manager.Add(organizationId, data);

            return new OkObjectResult(result);
        }

        [FunctionName("instructoravailability-put")]
        [ProducesResponseType(typeof(InstructorAvailability), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "instructoravailability/{organizationId}/{id}")]
            [RequestBodyType(typeof(InstructorAvailability),"Instructor")]HttpRequest req,
            ILogger log,
            string organizationId,
            string id)
        {
            if (!_authorizationManager.CanManageInstructors(req.HttpContext.User,organizationId)) return new UnauthorizedResult();

            var data = req.Content<InstructorAvailability>();
            var result = await _manager.Update(organizationId, id, data);

            return new OkObjectResult(result);
        }

        [FunctionName("instructoravailability-delete")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(
           [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "instructoravailability/{organizationId}/{id}")] HttpRequest req,
           ILogger log,
           string organizationId,
           string id)
        {
            if (!_authorizationManager.CanManageInstructors(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            await _manager.Delete(organizationId, id);

            return new OkResult();
        }
    }
}
