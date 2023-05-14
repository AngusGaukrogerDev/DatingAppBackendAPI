using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchFeedController : ControllerBase
    {
        [HttpGet("/api/MatchFeedController/GetNextUserInFeed")]
        public ActionResult GetNextUserInFeed()
        {
            return Ok();

        }

        [HttpPost("/api/MatchFeedController/SendLikeToCurrentUserInFeed")]
        public ActionResult SendLikeToCurrentUserInFeed()
        {
            return Ok();
        }

    }
}
