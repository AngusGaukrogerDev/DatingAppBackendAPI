using DatingApp.Logic.Matches.CheckForNewMatchesCommand;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesAndLikesController : Controller
    {
        private readonly ICheckForNewMatchesCommand _checkForNewMatchesCommand;
        public MatchesAndLikesController(ICheckForNewMatchesCommand checkForNewMatchesCommand)
        {
            _checkForNewMatchesCommand = checkForNewMatchesCommand;   
        }
        [HttpGet("/api/MatchesAndLikesController/CheckForNewMatches")]
        public ActionResult CheckForNewMatches() 
        {
            return Ok(CheckForNewMatches());
        }

    }
}
