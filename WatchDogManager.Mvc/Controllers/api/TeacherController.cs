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
        public HttpResponseMessage Get()
        {
            var result = _manager.Get();
            return Request.CreateResponse(result);
        }

        [HttpGet]
        [Route("api/teacher/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _manager.Get(id);
            return Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("api/teacher")]
        public HttpResponseMessage Post([FromBody]Models.api.Teacher value)
        {
            var result = _manager.Create(value);
            return Request.CreateResponse(result);
        }

        [HttpPut]
        [Route("api/teacher")]
        public HttpResponseMessage Put(int id, [FromBody]Models.api.Teacher value)
        {
            var result = _manager.Update(value);
            return Request.CreateResponse(result);
        }

        [HttpDelete]
        [Route("api/teacher")]
        public HttpResponseMessage Delete(int id)
        {
            _manager.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
