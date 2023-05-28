using DatingApp.Logic.Filters.FilterUsersByLocationCommand;
using DatingApp.Logic.Filters.FilterUsersByMatchingInterestsCommand;
using DatingApp.Models;

namespace DatingApp.Logic.MatchFeed.GetNextUserInFeedCommand
{
    public class GetNextUserInFeedCommand : IGetNextUserInFeedCommand
    {

        private readonly IFilterUsersByMatchingInterestsCommand _filterUsersByMatchingInterestsCommand;
        private readonly IFilterUsersByLocationCommand _filterUsersByLocationCommand;

        public GetNextUserInFeedCommand(IFilterUsersByMatchingInterestsCommand filterUsersByMatchingInterestsCommand, 
            IFilterUsersByLocationCommand filterUsersByLocationCommand)
        {

            _filterUsersByMatchingInterestsCommand = filterUsersByMatchingInterestsCommand;
            _filterUsersByLocationCommand = filterUsersByLocationCommand;
        }

        public StandardApplicationUser GetNextUserInFeed(int userId)
        {
            StandardApplicationUser nextFilteredUser = _filterUsersByMatchingInterestsCommand.SelectUserRandomlyFromListOfUsers(userId);
            StandardApplicationUser nextFilteredUserByLocation = _filterUsersByLocationCommand.SelectUserRandomlyFromListOfNearbyUsers(userId);

            return nextFilteredUser;
        }

        

    }
}
