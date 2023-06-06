using DatingApp.Data;
using DatingApp.Models;

namespace DatingApp.Logic.Matches.CheckForNewMatchesCommand
{
    public class CheckForNewMatchesCommand
    {
        private readonly IAppDbContext _appDbContext;
        public CheckForNewMatchesCommand(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<MatchesAndConversationProgress> CheckForNewMatches(StandardApplicationUser searchingUser)
        {
            List<MatchesAndConversationProgress> newMatches = new();

            UserLikesAndMatches usersLikeData = _appDbContext.UserLikesAndMatches.Where(u => u.Id == searchingUser.Id).FirstOrDefault();



            return newMatches;
        }
        
        private List<int> FilterSentAndReceivedLikesForMatches(UserLikesAndMatches usersLikes)
        {
            List<int> yeah = new();
            return yeah;
        }
    }
}
