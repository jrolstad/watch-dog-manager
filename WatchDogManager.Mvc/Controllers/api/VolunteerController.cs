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
    [Authorize]
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

        [HttpGet]
        [Route("api/volunteer")]
        public IHttpActionResult Get()
        {
            var result = _manager.Get();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/volunteer/{id}")]
        public IHttpActionResult Get(int id)
        {
            var result = _manager.Get(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/volunteer")]
        public IHttpActionResult Post([FromBody]Models.api.Volunteer value)
        {
            var result = _manager.Create(value);
            return Ok(result);
        }

        [HttpPut]
        [Route("api/volunteer")]
        public IHttpActionResult Put(int id, [FromBody]Models.api.Volunteer value)
        {
            var result = _manager.Update(value);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/volunteer/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _manager.Delete(id);
            return Ok(HttpStatusCode.OK);
        }
    }
}
