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

            List<StandardApplicationUser> filteredUsers = FindUsersMeetingSearchParametersFromDb(usersInterests);

            List<StandardApplicationUser> filteredUsersWithoutSearchingUser = new List<StandardApplicationUser>();

            foreach (var filteredUser in filteredUsers)
            {
                if(filteredUser.Id == userId)
                {
                    continue;
                }
                else
                {
                    filteredUsersWithoutSearchingUser.Add(filteredUser);
                }
            }

            return filteredUsersWithoutSearchingUser;

        }
        public List<StandardApplicationUser> GetFilteredUsersFromListByInterest(int userId, List<StandardApplicationUser> previouslyFilteredUsers)
        {

            List<string> usersInterests = GetUsersInterestsFromList(userId);

            List<StandardApplicationUser> filteredUsers = FindUsersMeetingSearchParameters(usersInterests, previouslyFilteredUsers);

            List<StandardApplicationUser> filteredUsersWithoutSearchingUser = new List<StandardApplicationUser>();

            foreach (var filteredUser in filteredUsers)
            {
                if (filteredUser.Id == userId)
                {
                    continue;
                }
                else
                {
                    filteredUsersWithoutSearchingUser.Add(filteredUser);
                }
            }

            return filteredUsersWithoutSearchingUser;

        }
        private List<string> GetUsersInterestsFromList(int userId)
        {

            List<string> interests = _appDbContext.StandardApplicationUser.Where(u => u.Id == userId).Select(u => u.Interests).FirstOrDefault();

            return interests;
        }

        private List<string> GetUsersInterests(int userId)
        {

            List<string> interests = _appDbContext.StandardApplicationUser.Where(u => u.Id == userId).Select(u => u.Interests).FirstOrDefault();

            return interests;
        }

        private List<StandardApplicationUser> FindUsersMeetingSearchParameters(List<string> searchingUsersInterests, List<StandardApplicationUser> listOfFilteredUsers)
        {

            List<StandardApplicationUser> usersWithMatchingInterests = listOfFilteredUsers.Where(u => searchingUsersInterests.All(interest => u.Interests.Contains(interest))).ToList();

            return usersWithMatchingInterests;

        }

        private List<StandardApplicationUser> FindUsersMeetingSearchParametersFromDb(List<string> searchingUsersInterests)
        {

            List<StandardApplicationUser> usersWithMatchingInterests = _appDbContext.StandardApplicationUser.Where(u => searchingUsersInterests.All(interest => u.Interests.Contains(interest))).ToList();

            return usersWithMatchingInterests;

        }
    }
}
