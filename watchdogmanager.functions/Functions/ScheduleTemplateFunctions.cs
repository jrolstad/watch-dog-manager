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
    public class ScheduleTemplateFunctions
    {
        private readonly AuthorizationManager _authorizationManager;
        private readonly ScheduleTemplateManager _manager;

        public ScheduleTemplateFunctions(AuthorizationManager authorizationManager, ScheduleTemplateManager manager)
        {
            _authorizationManager = authorizationManager;
            _manager = manager;
        }

        [FunctionName("scheduletemplate-list")]
        [ProducesResponseType(typeof(IEnumerable<ScheduleTemplate>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> List(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "scheduletemplate/{organizationId}")] HttpRequest req,
            string organizationId,
            ILogger log)
        {
            if (!_authorizationManager.CanManageScheduleTemplates(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var result = _manager.GetByOrganization(organizationId);

            return new OkObjectResult(result);
        }

        [FunctionName("scheduletemplate-get")]
        [ProducesResponseType(typeof(ScheduleTemplate), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "scheduletemplate/{organizationId}/{id}")] HttpRequest req,
            ILogger log,
            string organizationId,
            string id)
        {
            if (!_authorizationManager.CanManageScheduleTemplates(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var result = await _manager.GetById(organizationId, id);

            return new OkObjectResult(result);
        }

        [FunctionName("scheduletemplate-post")]
        [ProducesResponseType(typeof(ScheduleTemplate), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "scheduletemplate/{organizationId}")]
            [RequestBodyType(typeof(ScheduleTemplate),"ScheduleTemplate")]HttpRequest req,
            string organizationId,
            ILogger log)
        {
            if (!_authorizationManager.CanManageScheduleTemplates(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            var data = req.Content<ScheduleTemplate>();
            var result = await _manager.Add(organizationId, data);

            return new OkObjectResult(result);
        }

        [FunctionName("scheduletemplate-put")]
        [ProducesResponseType(typeof(ScheduleTemplate), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "scheduletemplate/{organizationId}/{id}")]
            [RequestBodyType(typeof(ScheduleTemplate),"ScheduleTemplate")]HttpRequest req,
            ILogger log,
            string organizationId,
            string id)
        {
            if (!_authorizationManager.CanManageScheduleTemplates(req.HttpContext.User,organizationId)) return new UnauthorizedResult();

            var data = req.Content<ScheduleTemplate>();
            var result = await _manager.Update(organizationId, id, data);

            return new OkObjectResult(result);
        }

        [FunctionName("scheduletemplate-delete")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(
           [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "scheduletemplate/{organizationId}/{id}")] HttpRequest req,
           ILogger log,
           string organizationId,
           string id)
        {
            if (!_authorizationManager.CanManageScheduleTemplates(req.HttpContext.User, organizationId)) return new UnauthorizedResult();

            await _manager.Delete(organizationId, id);

            return new OkResult();
        }
    }
}
