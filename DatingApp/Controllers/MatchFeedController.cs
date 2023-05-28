using DatingApp.Logic.MatchFeed.GetNextUserInFeedCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchFeedController : ControllerBase
    {
        private readonly ILogger<MatchFeedController> _logger;

        private readonly IGetNextUserInFeedCommand _getNextUserInFeedCommand;

        public MatchFeedController(ILogger<MatchFeedController> logger, IGetNextUserInFeedCommand getNextUserInFeedCommand)
        {
            _logger = logger;

            _getNextUserInFeedCommand = getNextUserInFeedCommand;
        }

        [HttpGet("/api/MatchFeedController/GetNextUserInFeed")]
        public ActionResult GetNextUserInFeed()
        {
            _getNextUserInFeedCommand.GetNextUserInFeed(1);

            return Ok();

        }

        [HttpPost("/api/MatchFeedController/SendLikeToCurrentUserInFeed")]
        public ActionResult SendLikeToCurrentUserInFeed()
        {
            return Ok();
        }

    }
}
