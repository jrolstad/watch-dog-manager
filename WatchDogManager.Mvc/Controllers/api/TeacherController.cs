using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchDogManager.EntityFramework;
using WatchDogManager.Mvc.Application.Managers;
using WatchDogManager.Mvc.Application.Mappers;

namespace WatchDogManager.Mvc.Controllers.api
{
    public class TeacherController : ApiController
    {
        private readonly TeacherManager _manager;

        public TeacherController():this(new TeacherManager(new WatchDogManagerDbContext(),new TeacherMapper()))
        {

        }
        public TeacherController(TeacherManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("api/teacher")]
        public IHttpActionResult Get()
        {
            var result = _manager.Get();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/teacher/{id}")]
        public IHttpActionResult Get(int id)
        {
            var result = _manager.Get(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/teacher")]
        public IHttpActionResult Post([FromBody]Models.api.Teacher value)
        {
            var result = _manager.Create(value);
            return Ok(result);
        }

        [HttpPut]
        [Route("api/teacher")]
        public IHttpActionResult Put(int id, [FromBody]Models.api.Teacher value)
        {
            var result = _manager.Update(value);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/teacher")]
        public IHttpActionResult Delete(int id)
        {
            _manager.Delete(id);
            return Ok(HttpStatusCode.OK);
        }
    }
}
