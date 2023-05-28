using DatingApp.Logic.Filters.FilterUsersByGenderCommand;
using DatingApp.Logic.Filters.FilterUsersByLocationCommand;
using DatingApp.Logic.Filters.FilterUsersByMatchingInterestsCommand;
using DatingApp.Models;

namespace DatingApp.Logic.MatchFeed.GetNextUserInFeedCommand
{
    public class GetNextUserInFeedCommand : IGetNextUserInFeedCommand
    {

        private readonly IFilterUsersByMatchingInterestsCommand _filterUsersByMatchingInterestsCommand;
        private readonly IFilterUsersByLocationCommand _filterUsersByLocationCommand;
        private readonly IFilterUsersByGenderCommand _filterUsersByGenderCommand;

        public GetNextUserInFeedCommand(IFilterUsersByMatchingInterestsCommand filterUsersByMatchingInterestsCommand,
            IFilterUsersByLocationCommand filterUsersByLocationCommand, IFilterUsersByGenderCommand filterUsersByGenderCommand)
        {
            _filterUsersByMatchingInterestsCommand = filterUsersByMatchingInterestsCommand;
            _filterUsersByLocationCommand = filterUsersByLocationCommand;
            _filterUsersByGenderCommand = filterUsersByGenderCommand;
        }

        public StandardApplicationUser GetNextUserInFeed(int userId)
        {
            //TODO: Angus - Change filter structure => Location, Gender (Based off preference),  Age, Interests
            //StandardApplicationUser nextFilteredUser = _filterUsersByMatchingInterestsCommand.SelectUserRandomlyFromListOfUsers(userId);
            //StandardApplicationUser nextFilteredUserByLocation = _filterUsersByLocationCommand.SelectUserRandomlyFromListOfNearbyUsers(userId);
            var random = new Random();

            //List<StandardApplicationUser> filteredUsers = _filterUsersByLocationCommand.GetListOfNearbyUsers(userId);
            List<StandardApplicationUser> filteredUsers = _filterUsersByGenderCommand.SelectUserRandomlyFromListOfUsersBasedOffCurrentUsersOrientation(userId);
            int index = random.Next(filteredUsers.Count);

            return filteredUsers[index];
        }


    }
}
