using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WatchDogManager.EntityFramework;
using WatchDogManager.Mvc.Application.Managers;
using WatchDogManager.Mvc.Application.Mappers;

namespace WatchDogManager.Mvc.Controllers.api
{
    public class VolunteerController : ApiController
    {
        private readonly VolunteerManager _manager;

        public VolunteerController():this(new VolunteerManager(new WatchDogManagerDbContext(),new VolunteerMapper()))
        {
            
        }
        public VolunteerController(VolunteerManager manager)
        {
            _manager = manager;
        }

        // GET: api/Volunteer
        public HttpResponseMessage Get()
        {
            var result = _manager.Get();
            return Request.CreateResponse(result);
        }

        // GET: api/Volunteer/5
        public HttpResponseMessage Get(int id)
        {
            var result = _manager.Get(id);
            return Request.CreateResponse(result);
        }

        // POST: api/Volunteer
        public HttpResponseMessage Post([FromBody]Models.api.Volunteer value)
        {
            var result = _manager.Create(value);
            return Request.CreateResponse(result);
        }

        // PUT: api/Volunteer/5
        public HttpResponseMessage Put(int id, [FromBody]Models.api.Volunteer value)
        {
            var result = _manager.Update(value);
            return Request.CreateResponse(result);
        }

        // DELETE: api/Volunteer/5
        public HttpResponseMessage Delete(int id)
        {
            _manager.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
