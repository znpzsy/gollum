using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace gollum.web.api.Controllers
{
    [RoutePrefix("api/v1/Playground")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlaygroundController : ApiController
    {
        [HttpGet]
        [Route("ping")]
        public IHttpActionResult NotSecured()
        {
            return this.Ok("All good. You don't need to be authenticated to call this.");
        }

        [Authorize]
        [HttpGet]
        [Route("secured/ping")]

        public IHttpActionResult Secured()
        {
            return this.Ok("All good. You only get this message if you are authenticated.");
        }
    }
}
