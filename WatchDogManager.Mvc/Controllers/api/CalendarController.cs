using System.Web.Http;
using WatchDogManager.Mvc.Models.api;

namespace WatchDogManager.Mvc.Controllers.api
{

    [Authorize]
    public class CalendarController : ApiController
    {
        [HttpGet]
        [Route("api/calendar")]
        public IHttpActionResult Get()
        {
            return Ok(new[]{new Calendar()});
        }

        [HttpGet]
        [Route("api/calendar/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(new Calendar());
        }

        [HttpPost]
        [Route("api/calendar")]
        public IHttpActionResult Post([FromBody]Calendar value)
        {
            return Ok(new Calendar());
        }

        [HttpPut]
        [Route("api/calendar")]
        public IHttpActionResult Put(int id, [FromBody]Calendar value)
        {
            return Ok(new Calendar());
        }

        [HttpDelete]
        [Route("api/calendar/{id}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
