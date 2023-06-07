using DatingApp.Models;

namespace DatingApp.Logic.Matches.CheckForNewMatchesCommand
{
    public interface ICheckForNewMatchesCommand
    {
        List<MatchesAndConversationProgress> CheckForNewMatches(StandardApplicationUser searchingUser);
    }
}