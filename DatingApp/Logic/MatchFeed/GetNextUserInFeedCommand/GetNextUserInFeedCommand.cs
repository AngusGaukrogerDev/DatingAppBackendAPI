using DatingApp.Logic.Filters.FilterUsersByAgeCommand;
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
        private readonly IFilterUsersByAgeCommand _filterUsersByAgeCommand;

        public GetNextUserInFeedCommand(IFilterUsersByMatchingInterestsCommand filterUsersByMatchingInterestsCommand,
            IFilterUsersByLocationCommand filterUsersByLocationCommand, IFilterUsersByGenderCommand filterUsersByGenderCommand,
            IFilterUsersByAgeCommand filterUsersByAgeCommand)
        {
            _filterUsersByMatchingInterestsCommand = filterUsersByMatchingInterestsCommand;
            _filterUsersByLocationCommand = filterUsersByLocationCommand;
            _filterUsersByGenderCommand = filterUsersByGenderCommand;
            _filterUsersByAgeCommand = filterUsersByAgeCommand;
        }

        public StandardApplicationUser GetNextUserInFeed(int userId)
        {
            //TODO: Angus - Change filter structure => Location, Gender (Based off preference),  Age, Interests
            var random = new Random();

            List<StandardApplicationUser> filteredUsersByLocation = _filterUsersByLocationCommand.GetListOfNearbyUsers(userId);
            List<StandardApplicationUser> filteredUsersByGender = _filterUsersByGenderCommand.SelectUserRandomlyFromListOfFilteredUsersBasedOffCurrentUsersOrientation(userId, filteredUsersByLocation);
            List<StandardApplicationUser> filteredUsersByAge = _filterUsersByAgeCommand.GetUsersBasedOffAge(userId, filteredUsersByGender);
            List<StandardApplicationUser> filteredUsersByMatchingInterests = _filterUsersByMatchingInterestsCommand.GetFilteredUsersFromListByInterest(userId, filteredUsersByAge);


            List<StandardApplicationUser> filteredUsers = new List<StandardApplicationUser>();
            filteredUsers.AddRange(filteredUsersByGender);
            filteredUsers.AddRange(filteredUsersByAge);
            filteredUsers.AddRange(filteredUsersByMatchingInterests);
            
            int index = random.Next(filteredUsers.Count);

            return filteredUsers[index];
        }
    }
}
