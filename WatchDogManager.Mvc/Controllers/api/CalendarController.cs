using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchDogManager.Mvc.Models.api;

namespace WatchDogManager.Mvc.Controllers.api
{
    [Authorize]
    public class CalendarController : ApiController
    {
        [HttpGet]
        [Route("api/calendar")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(new[] { new Calendar() });
        }

        [HttpGet]
        [Route("api/calendar/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(new Calendar());
        }

        [HttpPost]
        [Route("api/calendar")]
        public HttpResponseMessage Post([FromBody]Calendar value)
        {
            return Request.CreateResponse(new Calendar());
        }

        [HttpPut]
        [Route("api/calendar")]
        public HttpResponseMessage Put(int id, [FromBody]Calendar value)
        {
            return Request.CreateResponse(new Calendar());
        }

        [HttpDelete]
        [Route("api/calendar/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
