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
            var random = new Random();

            List<StandardApplicationUser> filteredUsersByGender = _filterUsersByGenderCommand.SelectUserRandomlyFromListOfUsersBasedOffCurrentUsersOrientation(userId);
            List<StandardApplicationUser> filteredUsersByLocation = _filterUsersByLocationCommand.GetListOfNearbyUsers(userId);
            List<StandardApplicationUser> filteredUsersByMatchingInterests = _filterUsersByMatchingInterestsCommand.GetFilteredUsersByInterest(userId);

            List<StandardApplicationUser> filteredUsers = new List<StandardApplicationUser>();
            filteredUsers.AddRange(filteredUsersByGender);
            filteredUsers.AddRange(filteredUsersByLocation);
            filteredUsers.AddRange(filteredUsersByMatchingInterests);
            
                int index = random.Next(filteredUsers.Count);

            return filteredUsers[index];
        }
    }
}
