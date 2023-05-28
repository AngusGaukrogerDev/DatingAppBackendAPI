using DatingApp.Data;
using DatingApp.Logic.MatchFeed.GetNextUserInFeedCommand;
using DatingApp.Models;

namespace DatingApp.Logic.Filters.FilterUsersByMatchingInterestsCommand
{
    public class FilterUsersByMatchingInterestsCommand : IFilterUsersByMatchingInterestsCommand
    {
        private readonly ILogger<FilterUsersByMatchingInterestsCommand> _logger;
        private readonly IAppDbContext _appDbContext;

        public FilterUsersByMatchingInterestsCommand(ILogger<FilterUsersByMatchingInterestsCommand> logger, IAppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public StandardApplicationUser SelectUserRandomlyFromListOfUsers(int userId)
        {
            var random = new Random();

            List<StandardApplicationUser> filteredUsers = GetFilteredUsersByInterest(userId);

            int index = random.Next(filteredUsers.Count);

            return filteredUsers[index];
        }

        public List<StandardApplicationUser> GetFilteredUsersByInterest(int userId)
        {

            List<string> usersInterests = GetUsersInterests(userId);

            List<StandardApplicationUser> filteredUsers = FindUsersMeetingSearchParameters(usersInterests);

            return filteredUsers;

        }

        private List<string> GetUsersInterests(int userId)
        {

            List<string> interests = _appDbContext.StandardApplicationUser.Where(u => u.Id == userId).Select(u => u.Interests).FirstOrDefault();

            //TODO: Angus - In future make this so that all interests do not have to be a match. Will return users with just 1 or 2 interests in common for 

            return interests;
        }

        private List<StandardApplicationUser> FindUsersMeetingSearchParameters(List<string> searchingUsersInterests)
        {

            List<StandardApplicationUser> usersWithMatchingInterests = _appDbContext.StandardApplicationUser.Where(u => searchingUsersInterests.All(interest => u.Interests.Contains(interest))).ToList();

            return usersWithMatchingInterests;

        }
    }
}
