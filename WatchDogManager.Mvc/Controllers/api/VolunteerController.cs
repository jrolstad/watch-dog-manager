using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WatchDogManager.Mvc.Models.api;

namespace WatchDogManager.Mvc.Controllers.api
{
    public class VolunteerController : ApiController
    {
        // GET: api/Volunteer
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(new[] {new Volunteer()});
        }

        // GET: api/Volunteer/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(new Volunteer());
        }

        // POST: api/Volunteer
        public HttpResponseMessage Post([FromBody]Volunteer value)
        {
            return Request.CreateResponse(new Volunteer());
        }

        // PUT: api/Volunteer/5
        public HttpResponseMessage Put(int id, [FromBody]Volunteer value)
        {
            return Request.CreateResponse(new Volunteer());
        }

        // DELETE: api/Volunteer/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
