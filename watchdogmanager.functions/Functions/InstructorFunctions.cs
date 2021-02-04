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
    public class InstructorFunctions
    {
        private readonly AuthorizationManager _authorizationManager;
        private readonly InstructorManager _manager;

        public InstructorFunctions(AuthorizationManager authorizationManager, InstructorManager manager)
        {
            _authorizationManager = authorizationManager;
            _manager = manager;
        }

        [FunctionName("instructor-list")]
        [ProducesResponseType(typeof(IEnumerable<Instructor>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> List(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "instructor/{organizationId}")] HttpRequest req,
            string organizationId,
            ILogger log)
        {
            if (!_authorizationManager.CanManageInstructors(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var result = _manager.GetByOrganization(organizationId);

            return new OkObjectResult(result);
        }

        [FunctionName("instructor-get")]
        [ProducesResponseType(typeof(Instructor), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "instructor/{organizationId}/{id}")] HttpRequest req,
            ILogger log,
            string organizationId,
            string id)
        {
            if (!_authorizationManager.CanManageInstructors(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var result = await _manager.GetById(organizationId, id);

            return new OkObjectResult(result);
        }

        [FunctionName("instructor-post")]
        [ProducesResponseType(typeof(Instructor), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "instructor/{organizationId}")]
            [RequestBodyType(typeof(Instructor),"Instructor")]HttpRequest req,
            string organizationId,
            ILogger log)
        {
            if (!_authorizationManager.CanManageInstructors(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var data = req.Content<Instructor>();
            var result = await _manager.Add(organizationId, data);

            return new OkObjectResult(result);
        }

        [FunctionName("instructor-put")]
        [ProducesResponseType(typeof(Instructor), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "instructor/{organizationId}/{id}")]
            [RequestBodyType(typeof(Instructor),"Instructor")]HttpRequest req,
            ILogger log,
            string organizationId,
            string id)
        {
            if (!_authorizationManager.CanManageInstructors(req.HttpContext.User,organizationId)) return new UnauthorizedResult();

            var data = req.Content<Instructor>();
            var result = await _manager.Update(organizationId, id, data);

            return new OkObjectResult(result);
        }

        [FunctionName("instructor-delete")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(
           [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "instructor/{organizationId}/{id}")] HttpRequest req,
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
