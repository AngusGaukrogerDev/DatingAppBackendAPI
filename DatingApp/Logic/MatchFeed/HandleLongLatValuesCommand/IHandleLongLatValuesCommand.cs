using DatingApp.Models;

namespace DatingApp.Logic.MatchFeed.HandleLongLatValuesCommand
{
    public interface IHandleLongLatValuesCommand
    {
        double CalculateDistanceFromUser(StandardApplicationUser searchingUser, StandardApplicationUser userInQuestion);
        double CalculateTotalDistance(double xDistance, double yDistance);
    }
}