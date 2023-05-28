using DatingApp.Models;

namespace DatingApp.Logic.MatchFeed.GetNextUserInFeedCommand
{
    public interface IGetNextUserInFeedCommand
    {
        StandardApplicationUser GetNextUserInFeed(int userId);
    }
}