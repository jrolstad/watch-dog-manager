using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchDogManager.Mvc.Models.api;

namespace WatchDogManager.Mvc.Controllers.api
{
    [Authorize]
    public class CalendarController : ApiController
    {
        // GET: api/Volunteer
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(new[] { new Calendar() });
        }

        // GET: api/Volunteer/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(new Calendar());
        }

        // POST: api/Volunteer
        public HttpResponseMessage Post([FromBody]Calendar value)
        {
            return Request.CreateResponse(new Calendar());
        }

        // PUT: api/Volunteer/5
        public HttpResponseMessage Put(int id, [FromBody]Calendar value)
        {
            return Request.CreateResponse(new Calendar());
        }

        // DELETE: api/Volunteer/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
